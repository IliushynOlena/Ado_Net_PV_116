using _07_EF_example.Entities;
using System;
using System.Linq;

namespace _07_EF_example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AirplaneDbContext context = new AirplaneDbContext();
            context.Clients.Add(new Client
            {
                Name = "Volodia",
                Birthday = new DateTime(2002, 2, 2),
                Email = "volodia@gmail.com"
            });

            context.SaveChanges();

            foreach (var c in context.Clients)
            {
                Console.WriteLine($" Client : {c.Id}  {c.Name} {c.Email}  {c.Birthday}");
            }

            var filter = context.Fligths.Where(f => f.ArrivelCity == "Lviv").OrderBy(f => f.ArrivelTime);
            foreach (var f in filter)
            {
                Console.WriteLine($"Flight :{f.Number} from {f.DepartureCity} to  {f.ArrivelCity}.Time  {f.DepartureTime}");
            }

            var client = context.Clients.Find(1);

            if(client != null)
            {
                context.Clients.Remove(client);
                context.SaveChanges();
            }

            foreach (var c in context.Clients)
            {
                Console.WriteLine($" Client : {c.Id}  {c.Name} {c.Email}  {c.Birthday}");
            }



        }
    }
}
