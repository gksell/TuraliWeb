using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TuraliWeb.Models;

namespace TuraliWeb.Controllers
{
    public class SubSubCategoriesController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: SubSubCategories
        public ActionResult Index()
        {
            var subSubCategories = db.SubSubCategories.Include(s => s.SubCategory);
            return View(subSubCategories.ToList());
        }

        // GET: SubSubCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubSubCategory subSubCategory = db.SubSubCategories.Find(id);
            if (subSubCategory == null)
            {
                return HttpNotFound();
            }
            return View(subSubCategory);
        }

        // GET: SubSubCategories/Create
        public ActionResult Create()
        {
            ViewBag.SubCategoryId = new SelectList(db.SubCategories, "Id", "Name");
            return View();
        }

        // POST: SubSubCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SubCategoryId,Name,Description,Image")] SubSubCategory subSubCategory)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    string DosyaAdi = Guid.NewGuid().ToString().Replace("-", "");
                    string uzanti = System.IO.Path.GetExtension(Request.Files[0].FileName);
                    string tamYolVeri = "~/Image/Categories/SubCategories/SubSubCategories/" + DosyaAdi + uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(tamYolVeri));
                    subSubCategory.Image = DosyaAdi + uzanti;
                }
                db.SubSubCategories.Add(subSubCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SubCategoryId = new SelectList(db.SubCategories, "Id", "Name", subSubCategory.SubCategoryId);
            return View(subSubCategory);
        }

        // GET: SubSubCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubSubCategory subSubCategory = db.SubSubCategories.Find(id);
            if (subSubCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubCategoryId = new SelectList(db.SubCategories, "Id", "Name", subSubCategory.SubCategoryId);
            return View(subSubCategory);
        }

        // POST: SubSubCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SubCategoryId,Name,Description,Image")] SubSubCategory subSubCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subSubCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubCategoryId = new SelectList(db.SubCategories, "Id", "Name", subSubCategory.SubCategoryId);
            return View(subSubCategory);
        }

        // GET: SubSubCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubSubCategory subSubCategory = db.SubSubCategories.Find(id);
            if (subSubCategory == null)
            {
                return HttpNotFound();
            }
            return View(subSubCategory);
        }

        // POST: SubSubCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubSubCategory subSubCategory = db.SubSubCategories.Find(id);
            db.SubSubCategories.Remove(subSubCategory);
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
