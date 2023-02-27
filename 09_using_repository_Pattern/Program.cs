using _07_EF_example;
using _07_EF_example.Entities;
using data_access_entity.Repository;
using System;
using System.Linq;

namespace _09_using_repository_Pattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IRepository<Flight> repository = new Repository<Flight>(new AirplaneDbContext());
            foreach (var f in repository.GetAll())
            {
                Console.WriteLine($"  {f.Number} From  {f.DepartureCity} to {f.ArrivelCity}" +
                    $" Id : {f.AirplaneId} flight  {f.Airplane?.Model}");
            }

           
            
        }
    }
}
