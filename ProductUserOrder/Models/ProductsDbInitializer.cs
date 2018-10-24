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
            Order order1 = null;
            Order order2 = null;
            Order order3 = null;
            Order order4 = null;
            Order order5 = null;

            Product product1 = new Product() { Id = 1, Name = "Pen", Price = 10, Description = "Black Pen", DateAdded = DateTime.Today };
            Product product2 = new Product() { Id = 2, Name = "Pencil", Price = 7, Description = "Red Pencil", DateAdded = DateTime.Today };
            Product product3 = new Product() { Id = 3, Name = "Bag", Price = 40, Description = "White Bag", DateAdded = DateTime.Today };
            Product product4 = new Product() { Id = 3, Name = "Tshirt", Price = 240, Description = "White TShirt", DateAdded = DateTime.Today };

            List<Order> orderList1 = new List<Order>() {order1, order2};
            List<Order> orderList2 = new List<Order>() { order3 };
            List<Order> orderList3 = new List<Order>() { order4, order5 };

            Customer customer1 = new Customer() { Id = 1, FirstName = "Alex", LastName = "Corrt", RegistrationDate = DateTime.Today, Email = "qwe@gmail.com", Orders = orderList1 };
            Customer customer2 = new Customer() { Id = 2, FirstName = "John", LastName = "Walker", RegistrationDate = DateTime.Today, Email = "dfg@gmail.com", Orders = orderList2 };
            Customer customer3 = new Customer() { Id = 3, FirstName = "Jack", LastName = "Daniels", RegistrationDate = DateTime.Today, Email = "opr@gmail.com", Orders = orderList3 };

            List<Product> productList1 = new List<Product>() {product1, product2};
            List<Product> productList2 = new List<Product>() { product3 };
            List<Product> productList3 = new List<Product>() { product2, product4 };
            List<Product> productList4 = new List<Product>() { product2, product3 };
            List<Product> productList5 = new List<Product>() { product2, product1, product3 };

            order1 = new Order() { Id = 1, Products = productList1, Customer = customer1, NumberOfProductsPurchased = productList1.Count, PurchasedDate = DateTime.Today };
            order2 = new Order() { Id = 2, Products = productList2, Customer = customer1, NumberOfProductsPurchased = productList2.Count, PurchasedDate = DateTime.Today };
            order3 = new Order() { Id = 3, Products = productList3, Customer = customer2, NumberOfProductsPurchased = productList3.Count, PurchasedDate = DateTime.Today };
            order4 = new Order() { Id = 4, Products = productList4, Customer = customer3, NumberOfProductsPurchased = productList4.Count, PurchasedDate = DateTime.Today };
            order5 = new Order() { Id = 5, Products = productList5, Customer = customer3, NumberOfProductsPurchased = productList5.Count, PurchasedDate = DateTime.Today };

            //context.Products.Add(product1);
            //context.Products.Add(product2);
            //context.Products.Add(product3);
            context.Products.AddRange(new List<Product>(){ product1, product2, product3, product4 });
            
            //context.Customers.Add(customer1);
            //context.Customers.Add(customer2);
            //context.Customers.Add(customer3);
            context.Customers.AddRange(new List<Customer>() {customer1, customer2, customer3});

            //context.Orders.Add(order1);
            //context.Orders.Add(order2);
            //context.Orders.Add(order3);

            context.Orders.AddRange(new List<Order>() {order1, order2, order3, order4, order5});
        }
    }
}