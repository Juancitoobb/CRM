using Crm.Maui.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.Maui.Persistence
{
    public class CrmDbContext : DbContext
    {
        //Entidades
        public DbSet<Customer> Customers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "crm.db");
            optionsBuilder.UseSqlite($"FileName={dbPath}");

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>()
                .HasData(
                new Customer
                {
                    Id = 1,
                    FirtName = "Burce",
                    LastName = "Wayne",
                    Email = "bruce.Wayne@mail.com"
                },
                new Customer
                {
                    Id = 2,
                    FirtName = "Peter",
                    LastName = "Parker",
                    Email = "peter.parker@mail.com"
                },
                new Customer
                {
                    Id = 3,
                    FirtName = "Tony",
                    LastName = "Stark",
                    Email = "tony.stark@mail.com"
                }
                );
        }
    }
}
