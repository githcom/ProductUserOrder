using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductOrderUser.Models
{
    public class Customer
    {
        //public int Id { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public DateTime RegistrationDate { get; set; }
        //public string Email { get; set; }
        //public IEnumerable<Order> Orders { get; set; }

        public Customer()
        {
                Orders = new List<Order>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Email { get; set; }
        public List<Order> Orders { get; set; }
    }

}