using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductOrderUser.Models;

namespace ProductUserOrder.Controllers
{
    public class HomeController : Controller
    {

        DataContex contex = new DataContex();

        public ActionResult Index()
        {
            ViewBag.Products = contex.Products.ToList();
            ViewBag.Customers = contex.Customers.ToList();
            ViewBag.Orders = contex.Orders.ToList();
            return View();
        }
        
        protected override void Dispose(bool disposing)
        {
            contex.Dispose();
            base.Dispose(disposing);
        }

    }
}