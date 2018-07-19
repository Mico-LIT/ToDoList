using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APP.DAL.Dapper;

namespace APP.Controllers
{
    public class HomeController : Controller
    {
        MobileContext db = new MobileContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\миша\source\repos\APP\APP\App_Data\Database1.mdf;Integrated Security=True");
        public ActionResult Index()
        {
            var ff = db.ToDoTask.Get(1);

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