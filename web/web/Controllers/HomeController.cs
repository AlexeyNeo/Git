using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Models;

namespace web.Controllers
{
    public class HomeController : Controller
    {
        private blogdb db = new blogdb();
        public ActionResult Index()
        {
            var category = db.Categories;
            var news = db.News;
          
            ViewBag.cat = news.ToList();
            return View( category.ToList());
        }

        [Authorize(Roles = @"admin")]
        public ActionResult Admin()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Контакты";

            return View();
        }
    }
}