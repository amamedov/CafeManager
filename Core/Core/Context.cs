using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Context : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<MenuPosition> MenuPositions { get; set; }
        public DbSet<MenuIngredient> MenuIngredients { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }
        public Context()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CafeDataBase;Trusted_Connection=True;");
        }
    }
}
