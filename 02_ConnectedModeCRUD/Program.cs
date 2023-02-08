using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
                               VALUES (@name, 
                                       @type, 
                                       @Quantity, 
                                       @CostPrice, 
                                       @Producer, 
                                       @Price)";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.Parameters.AddWithValue("name", product.Name);
            command.Parameters.AddWithValue("type", product.Type);
            command.Parameters.AddWithValue("Quantity", product.Quantity);
            command.Parameters.AddWithValue("CostPrice", product.CostPrice);
            command.Parameters.AddWithValue("Producer", product.Producer);
            command.Parameters.AddWithValue("Price", product.Price);
            command.CommandTimeout = 5;
            command.ExecuteNonQuery();

        }
        public List<Product> GetAll()
        {
            string cmdText = @"select * from Products";
            SqlCommand command = new SqlCommand(cmdText, connection);
            SqlDataReader reader = command.ExecuteReader();
            return this.GetProductByQuery(reader);
        }
        public List<Product> GetProductByName(string name)
        {
          
            string cmdText = $@"select * from Products where Name = @name";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.Parameters.Add("name", System.Data.SqlDbType.NVarChar).Value = name;

            //SqlParameter sql = new SqlParameter()
            //{
            //    ParameterName = "name",
            //    SqlDbType = System.Data.SqlDbType.NVarChar,
            //    Value = name
            //};
            //command.Parameters.Add(sql);

            SqlDataReader reader = command.ExecuteReader();
            return this.GetProductByQuery(reader);
        }
        private List<Product> GetProductByQuery(SqlDataReader reader)
        {
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
                               SET Name = @name, 
                                   TypeProduct =@type, 
                                   Quantity = @Quantity, 
                                   CostPrice =  @CostPrice, 
                                   Producer = @Producer, 
                                   Price =@Price
                                   WHERE Id = {product.Id}";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.Parameters.AddWithValue("name", product.Name);
            command.Parameters.AddWithValue("type", product.Type);
            command.Parameters.AddWithValue("Quantity", product.Quantity);
            command.Parameters.AddWithValue("CostPrice", product.CostPrice);
            command.Parameters.AddWithValue("Producer", product.Producer);
            command.Parameters.AddWithValue("Price", product.Price);
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
            return this.GetProductByQuery(reader).FirstOrDefault();
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
