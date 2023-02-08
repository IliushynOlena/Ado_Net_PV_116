
using data_access;
using data_access.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace _02_ConnectedModeCRUD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string connectionString = @"Data Source=DESKTOP-3HG9UVT\SQLEXPRESS;
                                 Initial Catalog=SportShop;Integrated Security=True;
                                 Connect Timeout=2;";
            SportShopDb db = new SportShopDb(connectionString);
            Product product = new Product()
            {
                Name = "Footbal shorts",
                Type = "Sport Clothes",
                Quantity = 150,
                CostPrice = 800,
                Producer = "Turkey",
                Price = 700
            };

            //db.Create(product);

            var p = db.GetAll();

            foreach (var item in p)
            {
                Console.WriteLine(item.Id + " " + item.Name + " " + item.CostPrice + " " + item.Producer);
            }
            Console.WriteLine();
            Console.WriteLine("Enter name of product to seach :");
            string name = Console.ReadLine();
            List<Product> products =  db.GetProductByName(name);
            foreach (var item in products)
            {
                Console.WriteLine(item.Id + " " + item.Name  +" " + item.CostPrice + " "+ item.Producer);
            }

            var p1 = db.GetOneById(29);
            Console.WriteLine(p1.Name);

            p1.Price = 200;
            p1.CostPrice = 300;
            p1.Quantity = 25;
            db.Update(p1);

           // db.Delete(24);

        }
    }
}
