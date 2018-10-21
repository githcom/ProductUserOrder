using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductOrderUser.Models;

namespace ProductUserOrder.Controllers
{
    public class OrderController : Controller
    {
        private DataContex contex = new DataContex();

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                contex.Orders.Add(order);
                contex.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(order);
        }

        public ActionResult Edit(int id = 0)
        {
            Order order = contex.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            //return View("Edit"  , "Product", order);
            //return RedirectToAction("../Product/Edit", order);
            return View("Edit", order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                contex.Entry(order).State = EntityState.Modified;
                contex.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(order);
        }

        public ActionResult Details(int id = 0)
        {
            Order order = contex.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View("Details", order);
        }

        public ActionResult Delete(int id = 0)
        {
            Order order = contex.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View("Delete", order);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = contex.Orders.Find(id);
            contex.Orders.Remove(order);
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