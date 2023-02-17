using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_linq_to_sql
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            ShopClassesDataContext dbContext = new ShopClassesDataContext();

            //CRUD - Create, Read, Update, Delete
            //Read
            //var products =  dbContext.Products;
            //foreach (var p in products)
            //{
            //    Console.WriteLine($"Product : {p.Id}  {p.Name}  {p.Price}$");
            //}

            //Filter
            //var products = dbContext.Products.Where(p => p.Price > 500).
            //    OrderByDescending(p => p.Price).Take(5);

            //var products = (from p in dbContext.Products
            //               where p.Price > 500
            //               orderby p.Price descending
            //               select p).Take(5);

            //foreach (var p in products)
            //{
            //    Console.WriteLine($"Product : {p.Id}  {p.Name}  {p.Price}$");
            //}

            //Create
            var product = new Product()
            {
                Name = "Bottle to water",
                TypeProduct = "Acessories",
                Quantity = 35,
                Price = 120,
                CostPrice = 75,
                Producer = "UA"
            };

            //dbContext.Products.InsertOnSubmit(product);
            //dbContext.Products.InsertOnSubmit(new Product() { });
            //dbContext.SubmitChanges();

            //Update
            //var productToEdit = dbContext.Products.Where(p => p.Id == 21).FirstOrDefault();
            //var productToEdit = dbContext.Products.FirstOrDefault(p => p.Id == 21);
            //productToEdit.Price -= 1000;

            //dbContext.SubmitChanges();

            //Delete
            var productToDelete = dbContext.Products.FirstOrDefault(p => p.Id == 21);

            if(productToDelete != null)
                dbContext.Products.DeleteOnSubmit(productToDelete);

            dbContext.SubmitChanges();
            var products = dbContext.Products;
            foreach (var p in products)
            {
                Console.WriteLine($"Product : {p.Id}  {p.Name}  {p.Price}$");
            }



            Console.ReadKey();
        }
    }
}
