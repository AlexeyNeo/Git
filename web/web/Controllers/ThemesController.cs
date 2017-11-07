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
    public class ThemesController : Controller
    {
        private blogdb db = new blogdb();

        // GET: Themes
        public ActionResult Index()
        {
            var themes = db.Themes.Include(t => t.Category1);
            return View(themes.ToList());
        }

        public ActionResult Category(byte id)
        {
            Theme theme = new Theme();
            
            var themes = db.Themes.Include(t => t.Category1).Where(t => t.category == id);
            var category = db.Categories.Where(m => m.id == id);
            ViewBag.id = id;
            ViewBag.t = category;
            return View("View",themes.ToList());
        }

        public ActionResult Read(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var theme = db.Themes.Find(id);
               
            return View(theme);
        }

        // GET: Themes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Theme theme = db.Themes.Find(id);
            if (theme == null)
            {
                return HttpNotFound();
            }
            return View(theme);
        }

        //public ActionResult View()
        //{
        //    var theme = db.Themes;
        //    return View(theme);
        //}


        // GET: Themes/Create
        [Authorize(Roles = @"admin")]
        public ActionResult Create()
        {
            ViewBag.category = new SelectList(db.Categories, "id", "text");
            return View();
        }

        // POST: Themes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = @"admin")]
        public ActionResult Create([Bind(Include = "id,title,body,Notes,createDate,editingDate,ThemeNotes,category")] Theme theme)
        {
            if (ModelState.IsValid)
            {
                theme.createDate = DateTime.Now;
                db.Themes.Add(theme);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.category = new SelectList(db.Categories, "id", "text", theme.category);
            return View(theme);
        }

        // GET: Themes/Edit/5
        [Authorize(Roles = @"admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Theme theme = db.Themes.Find(id);
            if (theme == null)
            {
                return HttpNotFound();
            }
            ViewBag.category = new SelectList(db.Categories, "id", "text", theme.category);
            return View(theme);
        }

        // POST: Themes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = @"admin")]
        public ActionResult Edit([Bind(Include = "id,title,body,Notes,createDate,editingDate,ThemeNotes,category")] Theme theme)
        {
            if (ModelState.IsValid)
            {
                db.Entry(theme).State = EntityState.Modified;
                theme.editingDate = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.category = new SelectList(db.Categories, "id", "text", theme.category);
            return View(theme);
        }

        // GET: Themes/Delete/5
        [Authorize(Roles = @"admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Theme theme = db.Themes.Find(id);
            if (theme == null)
            {
                return HttpNotFound();
            }
            return View(theme);
        }

        // POST: Themes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Theme theme = db.Themes.Find(id);
            db.Themes.Remove(theme);
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
