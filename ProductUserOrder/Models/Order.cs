using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductOrderUser.Models
{
    public class Order
    {
        //public int Id { get; set; }
        //public Product Products { get; set; }
        //public Customer Customer { get; set; }
        //public int NumberOfProductsPurchased { get; set; }
        //public DateTime PurchasedDate { get; set; }

        public Order()
        {
                Products = new List<Product>();
        }

        public int Id { get; set; }
        public List<Product> Products { get; set; }
        public Customer Customer { get; set; }
        public int NumberOfProductsPurchased { get; set; }
        public DateTime PurchasedDate { get; set; }

    }
}