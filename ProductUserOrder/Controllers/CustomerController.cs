using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProductOrderUser.Models;

namespace ProductUserOrder.Controllers
{
    public class CustomerController : Controller
    {
        private DataContex contex = new DataContex();

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                contex.Customers.Add(customer);
                contex.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(customer);
        }

        public ActionResult Edit(int id = 0)
        {
            Customer customer = contex.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            //return View("Edit"  , "Product", customer);
            //return RedirectToAction("../Product/Edit", customer);
            return View("Edit", customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                contex.Entry(customer).State = EntityState.Modified;
                contex.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(customer);
        }

        public ActionResult Details(int id = 0)
        {
            Customer customer = contex.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View("Details", customer);
        }

        public ActionResult Delete(int id = 0)
        {
            Customer customer = contex.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View("Delete", customer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = contex.Customers.Find(id);
            contex.Customers.Remove(customer);
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
