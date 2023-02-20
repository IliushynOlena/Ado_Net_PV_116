using _07_EF_example.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_EF_example
{
    internal class AirplaneDbContext : DbContext
    {
        public AirplaneDbContext()
        {
            //this.Database.EnsureDeleted();
            //this.Database.EnsureCreated();
        }
        //Collections
        //Clients
        //Flights
        //Airplanes
        public DbSet<Client> Clients { get; set; }
        public DbSet<Flight> Fligths { get; set; }
        public DbSet<Airplane> Airplanes { get; set; }       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-3HG9UVT\SQLEXPRESS;
                                        Initial Catalog = SuperPuperAirplaneDbWithMirgation;
                                        Integrated Security=True;
                                        Connect Timeout=2;Encrypt=False;
                                        TrustServerCertificate=False;
                                        ApplicationIntent=ReadWrite;
                                        MultiSubnetFailover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Initializer - Seeder
            modelBuilder.Entity<Airplane>().HasData(new Airplane[]
            {
                new Airplane()
                {
                    Id = 1,
                    Model = "Boeing 747",
                    MaxPassangers = 1200
                },
                new Airplane()
                {
                    Id = 2,
                    Model = "Boeing 425",
                    MaxPassangers = 1300
                }
            });

            modelBuilder.Entity<Flight>().HasData(new Flight[]
            {
                new Flight()
                {
                    Number = 1,
                    AirplaneId = 1,
                    DepartureCity = "Kyiv",
                    ArrivelCity = "Lviv",
                    DepartureTime = new DateTime(2023,3,3),
                    ArrivelTime = new DateTime(2023,3,3)

                },
                new Flight()
                {
                    Number = 2,
                    AirplaneId = 2,
                    DepartureCity = "Warsaw",
                    ArrivelCity = "Lviv",
                    DepartureTime = new DateTime(2023,3,3),
                    ArrivelTime = new DateTime(2023,3,3)

                }
            });
        }
    }
}
