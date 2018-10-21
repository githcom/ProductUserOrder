using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductOrderUser.Models;

namespace ProductUserOrder.Controllers
{
    public class SalesReportController : Controller
    {

        DataContex contex = new DataContex();


        // GET: SalesReport
        public ActionResult Open()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult GetSalesReport(string startDate, string endDate)
        {
            ViewBag.StartDate = startDate;
            ViewBag.EndDate = endDate;
            //04 / 26 / 2016
            DateTime start = DateTime.ParseExact(startDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime end = DateTime.ParseExact(endDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);


            var res = contex.Orders.Include(o => o.Products).Include(o => o.Customer)
                .Where(o => o.PurchasedDate >= start && o.PurchasedDate <= end).GroupBy(o => o.Products).ToList();

            /*Select(g => new { Product = g.Key, Count = g.Count() });*/

            //List<IGrouping<string, Order>> res = contex.Orders.Include(o => o.Products).Include(o => o.Customer)
            //  .Where(o => o.PurchasedDate >= start && o.PurchasedDate <= end).GroupBy(o => o.Products).ToList();

            //List<IGrouping<string, Order>> res2 = res;

            foreach (var VARIABLE in res)
            {
                Debug.WriteLine(VARIABLE.Key);
                Debug.WriteLine(VARIABLE.GetEnumerator().Current.Id);
                Debug.WriteLine(VARIABLE.GetEnumerator().Current.Customer);
                Debug.WriteLine(VARIABLE.GetEnumerator().Current.Products);
                Debug.WriteLine(VARIABLE.GetEnumerator().Current.NumberOfProductsPurchased);
                Debug.WriteLine(VARIABLE.GetEnumerator().Current.PurchasedDate);
            }


            Console.WriteLine();

            return View();
        }


    }
}