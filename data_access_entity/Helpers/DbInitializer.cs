using _07_EF_example.Entities;
using data_access_entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace _07_EF_example.Helpers
{
    internal static class DbInitializer
    {
        public static void SeedAirplanes(this ModelBuilder modelBuilder)
        {
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

        }
        public static void SeedFligths(this ModelBuilder modelBuilder)
        {
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
        public static void SeedCredentials(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Credentials>().HasData(new Credentials[]
        {
                new Credentials()
                {
                     Id = 1,
                     Login = "user1",
                     Password="1111"
                },
                new Credentials()
                {
                     Id = 2,
                     Login = "user2",
                     Password="2222"
                }
        });
        }
        public static void SeedClients(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasData(new Client[]
        {
                new Client()
                {
                      CredentialsId = 1,
                      Name = "Victor",
                      Birthday= new DateTime(2000,3,3),
                      Email = "victor@gmail.com"
                },
                new Client()
                {

                      CredentialsId = 2,
                      Name = "Olga",
                      Birthday= new DateTime(2005,3,3),
                      Email = "olga@gmail.com"
                }
        });
        }
    }
}
