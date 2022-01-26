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
    public class ProductsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.SubSubCategory);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.SubSubCategoryId = new SelectList(db.SubSubCategories, "Id", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PDF,UploadTime,Price,IsApproved,SubSubCategoryId,Name,Description,Image")] Products products)
        {
            if (Request.Files.Count > 0)
            {
                string DosyaAdi = Guid.NewGuid().ToString().Replace("-", "");
                string uzanti = System.IO.Path.GetExtension(Request.Files[0].FileName);
                if (uzanti.Contains(".pdf"))
                {
                    string tamYolVeri = "~/PDF/" + DosyaAdi + uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(tamYolVeri));
                    products.PDF = DosyaAdi + uzanti;
                }
                else
                {
                    products.PDF = null;
                    ViewBag.SubSubCategoryId = new SelectList(db.SubSubCategories, "Id", "Name", products.SubSubCategoryId);
                    return View(products);
                }
            }

            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    string DosyaAdi = Guid.NewGuid().ToString().Replace("-", "");
                    string uzanti = System.IO.Path.GetExtension(Request.Files[0].FileName);
                    string tamYolVeri = "~/PDF/" + DosyaAdi + uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(tamYolVeri));
                    products.PDF = DosyaAdi + uzanti;
                    
                }
                if (Request.Files.Count > 0)
                {
                    string DosyaAdi = Guid.NewGuid().ToString().Replace("-", "");
                    string uzanti = System.IO.Path.GetExtension(Request.Files[0].FileName);
                    string tamYolVeri = "~/Image/Categories/SubCategories/SubSubCategories/Products/" + DosyaAdi + uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(tamYolVeri));
                    products.Image = DosyaAdi + uzanti;
                }

                products.UploadTime = DateTime.Now;
                db.Products.Add(products);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SubSubCategoryId = new SelectList(db.SubSubCategories, "Id", "Name", products.SubSubCategoryId);
            return View(products);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubSubCategoryId = new SelectList(db.SubSubCategories, "Id", "Name", products.SubSubCategoryId);
            return View(products);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PDF,UploadTime,Price,IsApproved,SubSubCategoryId,Name,Description,Image")] Products products)
        {
            if (ModelState.IsValid)
            {
                db.Entry(products).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubSubCategoryId = new SelectList(db.SubSubCategories, "Id", "Name", products.SubSubCategoryId);
            return View(products);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Products products = db.Products.Find(id);
            db.Products.Remove(products);
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
