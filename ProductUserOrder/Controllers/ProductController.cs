using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductOrderUser.Models;

namespace ProductUserOrder.Controllers
{
    public class ProductController : Controller
    {
        DataContex contex = new DataContex();

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                contex.Products.Add(product);
                contex.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(product);
        }

        public ActionResult Edit(int id = 0)
        {
            Product product = contex.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            //return View("Edit"  , "Product", product);
            //return RedirectToAction("../Product/Edit", product);
            return View("Edit", product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                contex.Entry(product).State = EntityState.Modified;
                contex.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(product);
        }

        public ActionResult Details(int id = 0)
        {
            Product product = contex.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View("Details", product);
        }

        public ActionResult Delete(int id = 0)
        {
            Product product = contex.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View("Delete", product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = contex.Products.Find(id);
            contex.Products.Remove(product);
            contex.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            contex.Dispose();
            base.Dispose(disposing);
        }

    }
}
