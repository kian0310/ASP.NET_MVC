using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            //models.class1 class1 = new models.class1();
            //class1.username = "i love you";
            //↑old 寫法
            //↓new 寫法
            Class1 class1 = new Class1
            {
                UserName = "I love you"
            };

            return View(class1);
            //example: return Content("XXXXXX");  //傳回"string"、一段文字
        }

        public ActionResult mis2000lab()
        {
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