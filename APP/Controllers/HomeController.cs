using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APP.BLL.Interfaces;

namespace APP.Controllers
{
    public class HomeController : Controller
    {

        ITaskListService TLService;

        public HomeController(ITaskListService service)
        {
            TLService = service;
        }

        public ActionResult Index()
        {
            var ff = TLService.GetTasks();
            var gg = TLService.GetTask(9);

            //var ff2 = db.ToDoTask.Update(new DAL.Entities.TaskList() {
            //    Id=3,
            //    DateStart=DateTime.Today.Date,
            //    DeadLine= DateTime.Today.AddDays(20),
            //    Mess="ОК123",
            //    Priority=new DAL.Entities.TaskListPriority() { Id = (int)DAL.Entities.TaskListPriorityEnum.Низкий}

            //});

            //var ff3 = db.ToDoTask.Create(new DAL.Entities.TaskList()
            //{
            //    DateStart = DateTime.Today.Date,
            //    DeadLine = DateTime.Today.AddDays(20),
            //    DateEnd = DateTime.Today.AddDays(10),
            //    Mess = "Отчет",
            //    Priority = new DAL.Entities.TaskListPriority() { Id = (int)DAL.Entities.TaskListPriorityEnum.Высокий }

            //});

            //var ff4 = db.ToDoTask.GetAll();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}