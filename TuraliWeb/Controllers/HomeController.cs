using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TuraliWeb.Models;

namespace TuraliWeb.Controllers
{
    public class HomeController : Controller
    {
         private DatabaseContext db = new DatabaseContext();
        // GET: Home
        public ActionResult Index()
        {
            ViewModel vm = new ViewModel();
            vm.Categories = db.Category.ToList();
            vm.SubCategories = db.SubCategories.ToList();
            vm.SubSubCategories= db.SubSubCategories.ToList();
            vm.Products = db.Products.ToList();
            return View(vm);
        }
        public PartialViewResult _NavPartial()
        {
            ViewModel vm = new ViewModel();
            vm.Categories = db.Category.ToList();
            vm.SubCategories = db.SubCategories.ToList();
            vm.SubSubCategories = db.SubSubCategories.ToList();
            vm.Products = db.Products.ToList();
            return PartialView("_NavPartial",vm);
        }
        public ActionResult AllList()
        {
            var k = db.Category.ToList();
            return View(k);
        }
        public ActionResult SubCategoriList(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category subCategory = db.Category.Find(id);
            if (subCategory == null)
            {
                return HttpNotFound();
            }

            var k = subCategory.SubCategories.ToList();
             
            return View(k);
        }
        public ActionResult SubSubCategoriList(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategory subCategory = db.SubCategories.Find(id);
            if (subCategory == null)
            {
                return HttpNotFound();
            }

            var k = subCategory.SubSubCategories.ToList();

            return View(k);
        }
        public ActionResult Products(int? id)
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

            var k = subSubCategory.Products.ToList();

            return View(k);
        }
        public ActionResult AllProductsList()
        {
            var k = db.Products.ToList();
            return View(k);
        }
        public ActionResult ProductDetail(int? id)
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

    }
}