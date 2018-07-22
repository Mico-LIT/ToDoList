using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APP.Models;
using APP.BLL.Interfaces;
using APP.BLL.DTO;
using AutoMapper;
using PagedList;

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
        public ActionResult Index(int? page)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TaskListDTO, TaskListViewModel>()).CreateMapper();
            var list = mapper.Map<IEnumerable<TaskListDTO>, IEnumerable<TaskListViewModel>>(tlService.GetTaskAll());

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(list.ToPagedList(pageNumber, pageSize));
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
                    var mapper = new MapperConfiguration(
                        cfg => cfg.CreateMap<TaskListViewModel, TaskListDTO>().
                        ForMember(x => x.Priority,
                        y => 
                        y.MapFrom(sours => new TaskListPriorityDTO()
                        {
                            Id = int.Parse(sours.PriorityID)
                        }))).CreateMapper();

                    tlService.CreateNewTask(mapper.Map<TaskListViewModel, TaskListDTO>(viewModel));

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
            ViewBag.Priority = mapper.Map<IEnumerable<TaskListPriorityDTO>, IEnumerable<TaskListPriorityViewModel>>(tlService.PriorityAll());

            var mapper2 = new MapperConfiguration(cfg => cfg.CreateMap<TaskListDTO, TaskListViewModel>()).CreateMapper();
            return View(mapper2.Map<TaskListDTO, TaskListViewModel>(tlService.GetTask(id.Value)));
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
