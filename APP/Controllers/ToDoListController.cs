using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APP.Models;
using APP.BLL.Interfaces;
using APP.BLL.DTO;
using AutoMapper;

namespace APP.Controllers
{
    public class ToDoListController : Controller
    {
        ITaskListService tlService;
        public ToDoListController(ITaskListService taskListService)
        {
            tlService = taskListService;
        }

        // GET: ToDoList
        public ActionResult Index()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TaskListDTO, TaskListViewModel>()).CreateMapper();
            var list = mapper.Map<IEnumerable<TaskListDTO>, IEnumerable<TaskListViewModel>>(tlService.GetTaskAll());
            return View(list);
        }

        // GET: ToDoList/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) return RedirectToAction("Index");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TaskListDTO, TaskListViewModel>()).CreateMapper();
            var list = mapper.Map<TaskListDTO, TaskListViewModel>(tlService.GetTask(id));
            return View(list);
        }

        // GET: ToDoList/Create
        public ActionResult Create()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TaskListPriorityDTO, TaskListPriorityViewModel>()).CreateMapper();
            var list = mapper.Map<IEnumerable<TaskListPriorityDTO>, IEnumerable<TaskListPriorityViewModel>>(tlService.PriorityAll());
            ViewBag.Priority = list;


            return View();
        }

        // POST: ToDoList/Create
        [HttpPost]
        public ActionResult Create(TaskListViewModel viewModel)
        {
            try
            {
                TaskListDTO taskListDTO = new TaskListDTO()
                {
                    Priority = new TaskListPriorityDTO() { Id = int.Parse(viewModel.PriorityID) },
                    DateEnd = viewModel.DateEnd,
                    DateStart = viewModel.DateStart.Value,
                    DeadLine = viewModel.DeadLine.Value,
                    Mess = viewModel.Mess
                };

                tlService.CreateNewTask(taskListDTO);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ToDoList/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) return RedirectToAction("Index");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TaskListPriorityDTO, TaskListPriorityViewModel>()).CreateMapper();
            var Prioritylist = mapper.Map<IEnumerable<TaskListPriorityDTO>, IEnumerable<TaskListPriorityViewModel>>(tlService.PriorityAll());
            ViewBag.Priority = Prioritylist;

            var mapper2 = new MapperConfiguration(cfg => cfg.CreateMap<TaskListDTO, TaskListViewModel>()).CreateMapper();
            var list2 = mapper2.Map<TaskListDTO, TaskListViewModel>(tlService.GetTask(id.Value));
            return View(list2);
        }

        // POST: ToDoList/Edit/5
        [HttpPost]
        public ActionResult Edit(TaskListViewModel viewModel)
        {
            try
            {
                var mapper =
                    new MapperConfiguration(
                        cfg => cfg.CreateMap<TaskListViewModel, TaskListDTO>().
                        ForMember(x => x.Priority,
                        y=>y.MapFrom(sours=> new TaskListPriorityDTO() {
                           Id=int.Parse(sours.PriorityID)
                        }))).CreateMapper();

                if (tlService.Update(mapper.Map<TaskListViewModel, TaskListDTO>(viewModel)))
                {
                    return RedirectToAction("Index");
                }
                throw new Exception("Ошибка при обновлении");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        // GET: ToDoList/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) return RedirectToAction("Index");

            if (tlService.Delete(id.Value))
            {
                return RedirectToAction("Index");
            }
            return null;
        }

        // POST: ToDoList/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            return null;
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
