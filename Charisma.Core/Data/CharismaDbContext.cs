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
        public DbSet<Ingredient> Ingredients { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=tcp:charismaserver.database.windows.net,1433;Initial Catalog=CharismaDb;Persist Security Info=False;User ID=charisma;Password=Far1898859;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Defining the schema
            modelBuilder.HasDefaultSchema("CharismaMenu");

            // MenuItemType
            //modelBuilder.Entity<MenuItemType>().HasKey(c => c.Name);

            // MenuItemSubType
            //modelBuilder.Entity<MenuItemSubType>().HasKey(k => new { k.Name });

            modelBuilder.Entity<MenuItemSubType>()
                .HasOne(p => p.Owner)
                .WithMany(b => b.Members);

            // MenuItem
            //modelBuilder.Entity<MenuItem>().HasKey(k => new { k.Name });

            modelBuilder.Entity<MenuItem>()
                .HasOne(p => p.SubType)
                .WithMany(b => b.Members);

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
                .HasOne(p => p.MenuItem)
                .WithMany(b => b.Members);
        }
    }
}
