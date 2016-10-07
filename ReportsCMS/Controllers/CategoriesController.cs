using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ReportsCMS.DAL;
using ReportsCMS.Models;

namespace ReportsCMS.Controllers
{
    public class CategoriesController : Controller
    {
        private CategoryContext db = new CategoryContext();

        // GET: Categories
        public ActionResult Index()
        {
            var categoryList = db.Categories.ToList();
            var reports = db.ReportLinkses.ToList().Where(r=>r.Display==true);
            var reportviewmodel = new List<ReportsViewModel>();
            foreach (var category in categoryList)
            {
                var list = new List<ReportLinks>();
                foreach (var report in reports)
                {
                    if (category.Id == report.ParentCategoryId)
                    {
                        list.Add(report);
                    }
                }
                reportviewmodel.Add(new ReportsViewModel() { Id = category.Id, CategoryName = category.Name, ReportLinkses = list });
            }
            return View(reportviewmodel);
        }

        public ActionResult ManageReports()
        {
            var reports = db.ReportLinkses.ToList();
            return View(reports);
        }


        // GET: Categories/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Categories/Create
        public ActionResult CreateCategory()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                category.Id = Guid.NewGuid();
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ParentCategoryId,Link,Display")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
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

        public ActionResult CreateReport()
        {
            var categories = db.Categories.ToList();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateReport(ReportLinks reportLink)
        {
            if (ModelState.IsValid)
            {
                reportLink.Id = Guid.NewGuid();
                db.ReportLinkses.Add(reportLink);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reportLink);
        }
    }

    public class ReportsViewModel
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public List<ReportLinks> ReportLinkses { get; set; }
    }
}
