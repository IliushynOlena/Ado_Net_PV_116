using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
                                        Initial Catalog = SuperPuperAirplaneDb;
                                        Integrated Security=True;
                                        Connect Timeout=2;Encrypt=False;
                                        TrustServerCertificate=False;
                                        ApplicationIntent=ReadWrite;
                                        MultiSubnetFailover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Initializer
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
    [Table("Passengers")]
    class Client
    {
        //Primary key naming : Id/id/ID/ EntityName + Id
        public int Id { get; set; }
        [Required, MaxLength(100)]//not null nvarchar(100)
        [Column("FirstName")]
        public string Name { get; set; }
        [Required, MaxLength(50)]
        public string Email { get; set; }
        public DateTime? Birthday { get; set; }

        public ICollection<Flight> Flights { get; set; }
    }
    class Flight
    {
        [Key]//set primary key
        public int Number { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivelTime { get; set; }
        [Required, MaxLength(100)]
        public string DepartureCity { get; set; }
        [Required, MaxLength(100)]
        public string ArrivelCity { get; set; }
        //Relationship type : one to many
        //Foreighn key : RelatedEntityName + RelatedEntityPrimaryKeyName
        public int AirplaneId { get; set; }
        public Airplane Airplane { get; set; }
        public ICollection<Client> Clients { get; set; }

    }
    class Airplane
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int MaxPassangers { get; set; }

        public ICollection<Flight> Flights { get; set; }

    }
}
