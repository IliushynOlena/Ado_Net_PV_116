using _07_EF_example.Entities;
using _07_EF_example.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
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
            modelBuilder.SeedAirplanes();
            modelBuilder.SeedFligths();

        

            //Fluent API configuration
            modelBuilder.Entity<Airplane>().Property(a => a.Model)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Client>().ToTable("Passengers");
            modelBuilder.Entity<Client>().Property(c => c.Name)
              .IsRequired()//not null 
              .HasMaxLength(100)
              .HasColumnName("FirstName");//nvarchar(100)
            modelBuilder.Entity<Client>().Property(c => c.Email)
            .IsRequired()//not null 
            .HasMaxLength(100);

            modelBuilder.Entity<Flight>().HasKey(f => f.Number);//set primary key
            modelBuilder.Entity<Flight>().Property(f => f.ArrivelCity)
             .IsRequired()//not null 
             .HasMaxLength(100);
            modelBuilder.Entity<Flight>().Property(f => f.DepartureCity)
             .IsRequired()//not null 
             .HasMaxLength(100);

            //Relationships configuration
            modelBuilder.Entity<Airplane>()
                .HasMany(a => a.Flights)
                .WithOne(f => f.Airplane)
                .HasForeignKey(f=>f.AirplaneId);
            //modelBuilder.Entity<Flight>().HasOne(f => f.Airplane).WithMany(a => a.Flights);

            modelBuilder.Entity<Flight>()
                .HasMany(f => f.Clients)
                .WithMany(c => c.Flights);

        }
    }
}
