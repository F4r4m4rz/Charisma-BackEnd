using System;
using Charisma.Core.Model.Events;
using Charisma.Core.Model.Menu;
using Microsoft.EntityFrameworkCore;

namespace Charisma.Core.Data
{
    public class CharismaDbContext : DbContext
    {
        public CharismaDbContext(DbContextOptions<CharismaDbContext> options)
            : base(options)
        {

        }

        public DbSet<MenuItem> Menu { get; set; }
        public DbSet<MenuItemType> MenuItemTypes { get; set; }
        public DbSet<MenuItemSubType> MenuItemSubTypes { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = CharismaDb;Integrated Security=true;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Defining the schema
            modelBuilder.HasDefaultSchema("Menu");

            // MenuItemType
            //modelBuilder.Entity<MenuItemType>().HasKey(c => c.Name);

            // MenuItemSubType
            //modelBuilder.Entity<MenuItemSubType>().HasKey(k => new { k.Name });

            modelBuilder.Entity<MenuItemSubType>()
                .HasOne(p => p.Owner)
                .WithMany(b => b.SubTypes);

            // MenuItem
            //modelBuilder.Entity<MenuItem>().HasKey(k => new { k.Name });

            modelBuilder.Entity<MenuItem>()
                .HasOne(p => p.SubType)
                .WithMany(b => b.MenuItem);

            modelBuilder.Entity<MenuItem>()
                .Property<TimeSpan>("WaitingTime")
                .HasDefaultValue(TimeSpan.Parse("0:0:0"));

            modelBuilder.Entity<MenuItem>()
                .Property<bool>("IsAvailable")
                .HasDefaultValue(true);

            // Recipe
            //modelBuilder.Entity<Recipe>().HasKey(k => k.Name);

            // Ingredient
            //modelBuilder.Entity<Ingredient>().HasKey(k => k.Name);

            modelBuilder.Entity<Ingredient>()
                .HasOne(p => p.Recipe)
                .WithMany(b => b.Ingredients);
        }
    }
}
