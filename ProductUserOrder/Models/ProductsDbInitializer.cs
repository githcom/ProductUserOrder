using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ProductOrderUser.Models;

namespace ProductUserOrder.Models
{
    public class ProductsDbInitializer : DropCreateDatabaseIfModelChanges<DataContex>
    {
        

        protected override void Seed(DataContex context)
        {
            Product product1 = new Product() { Id = 1, Name = "Pen", Price = 10, Description = "Black Pen", DateAdded = DateTime.Today };
            Product product2 = new Product() { Id = 2, Name = "Pencil", Price = 7, Description = "Red Pencil", DateAdded = DateTime.Today };
            Product product3 = new Product() { Id = 3, Name = "Bag", Price = 40, Description = "White Bag", DateAdded = DateTime.Today };

            Customer customer1 = new Customer() { Id = 1, FirstName = "Alex", LastName = "Corrt", RegistrationDate = DateTime.Today, Email = "qwe@gmail.com", Orders = new Int32[] {  } };

            Order order1 = new Order() { Id = 1, Products = product1.Name, Customer = customer1.LastName, NumberOfProductsPurchased = 2, PurchasedDate = DateTime.Today };
            Order order2 = new Order() { Id = 2, Products = product3.Name, Customer = customer1.LastName, NumberOfProductsPurchased = 3, PurchasedDate = DateTime.Today };
            Order order3 = new Order() { Id = 3, Products = product2.Name, Customer = customer1.LastName, NumberOfProductsPurchased = 1, PurchasedDate = DateTime.Today };

            
            Customer customer2 = new Customer() { Id = 2, FirstName = "John", LastName = "Walker", RegistrationDate = DateTime.Today, Email = "dfg@gmail.com", Orders = new Int32[] { order2.Id } };
            Customer customer3 = new Customer() { Id = 3, FirstName = "Jack", LastName = "Daniels", RegistrationDate = DateTime.Today, Email = "opr@gmail.com", Orders = new Int32[] { order3.Id, order2.Id } };
            
            context.Products.Add(product1);
            context.Products.Add(product2);
            context.Products.Add(product3);

            
            //context.Customers.Add(customer1);
            context.Customers.Add(customer2);
            context.Customers.Add(customer3);

            

            context.Orders.Add(order1);
            context.Orders.Add(order2);
            context.Orders.Add(order3);
        }
    }
}