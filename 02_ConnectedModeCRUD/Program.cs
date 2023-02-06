using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace _02_ConnectedModeCRUD
{
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public int CostPrice { get; set; }
        public string Producer { get; set; }
        public int Price { get; set; }
    }
    class SportShopDb
    {
        //CRUD interface
        //[C]reate
        //[R]ead
        //[U]pdate
        //[D]elete
        private SqlConnection connection;
       
        public SportShopDb(string connectionString)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
        }
        ~SportShopDb()
        {
            connection.Close();
        }
        public void Create(Product product)
        {
            string cmdText = $@"INSERT INTO Products
                               VALUES ('{product.Name}', 
                                       '{product.Type}', 
                                        {product.Quantity}, 
                                        {product.CostPrice}, 
                                       '{product.Producer}', 
                                        {product.Price})";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.CommandTimeout = 5;
            command.ExecuteNonQuery();

        }
        public List<Product> GetAll()
        {
            string cmdText = @"select * from Products";
            SqlCommand command = new SqlCommand(cmdText, connection);
            SqlDataReader reader = command.ExecuteReader();
            List<Product> products = new List<Product>();
          
            while (reader.Read())
            {
                products.Add(new Product()
                {
                    Id = (int)reader[0],
                    Name = (string)reader[1],
                    Type = (string)reader[2],
                    Quantity = (int)reader[3],
                    CostPrice = (int)reader[4],
                    Producer = (string)reader[5],
                    Price = (int)reader[6]
                });
            }
            reader.Close();
            return products;
        }
        public void Update(Product product)
        {
            string cmdText = $@"UPDATE Products
                               SET Name = '{product.Name}', 
                                   TypeProduct ='{product.Type}', 
                                   Quantity = {product.Quantity}, 
                                   CostPrice =  {product.CostPrice}, 
                                   Producer =  '{product.Producer}', 
                                   Price = {product.Price}
                                   WHERE Id = {product.Id}";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.CommandTimeout = 5;
            command.ExecuteNonQuery();
        }
        public void Delete(int id)
        {
            string cmdText = $@"delete Products where Id = {id}";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.ExecuteNonQuery();
        }
        public Product GetOneById(int id)
        {
            string cmdText = $@"select * from Products WHERE Id = {id}";
            SqlCommand command = new SqlCommand(cmdText, connection);
            SqlDataReader reader = command.ExecuteReader();
           Product product = new Product();

            while (reader.Read())
            {

                product.Id = (int)reader[0];
                product.Name = (string)reader[1];
                product.Type = (string)reader[2];
                product.Quantity = (int)reader[3];
                product.CostPrice = (int)reader[4];
                product.Producer = (string)reader[5];
                product.Price = (int)reader[6];
              
            }
            reader.Close();
            return product;
        }
    }
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
                Name = "Espander",
                Type = "Sport equipment",
                Quantity = 2,
                CostPrice = 300,
                Producer = "UA",
                Price = 125
            };

            //db.Create(product);

            //var p = db.GetAll();
            //foreach (var item in p)
            //{
            //    Console.WriteLine(item.Id + " " + item.Name);
            //}

            //var p = db.GetOneById(3);
            //Console.WriteLine(p.Name);

            //p.Price = 500;
            //p.CostPrice = 1000;
            //p.Quantity = 50;
            //db.Update(p);

            db.Delete(24);

        }
    }
}
