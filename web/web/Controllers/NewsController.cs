using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using web.Models;

namespace web.Controllers
{
    public class NewsController : Controller
    {
        private blogdb db = new blogdb();

        // GET: News
        //public ActionResult Index()
        //{
        //    return View(db.News.ToList());
        //}

        [Authorize(Roles = @"admin")]
        public ActionResult View()
        {

            return View("View", db.News.ToList());

        }

        public ActionResult Index(int? id)
        {
            if (id == null)
                return View(db.News.ToList());
            ViewBag.news = db.News.Where(m => m.id == id);
            return View("Index");
        }


        // GET: News/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }
       
        // GET: News/Create
        [Authorize(Roles = @"admin")]
        public ActionResult Create()
        {
            return View("Create");
            
        }

        // POST: News/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = @"admin")]
        public ActionResult Create([Bind(Include = "id,title,body")] News news)
        {
            if (ModelState.IsValid)
            {
                news.date = DateTime.Now;
                
                db.News.Add(news);
                db.SaveChanges();
                return RedirectToAction("View");
            }

            return View("View");
        }

        [Authorize(Roles = @"admin")]
        // GET: News/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View();
        }

        // POST: News/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = @"admin")]
        public ActionResult Edit([Bind(Include = "id,title,body,date")] News news)
        {
            if (ModelState.IsValid)
            {
                db.Entry(news).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("View");
        }
        [Authorize(Roles = @"admin")]
        // GET: News/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            News news = db.News.Find(id);
            db.News.Remove(news);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
