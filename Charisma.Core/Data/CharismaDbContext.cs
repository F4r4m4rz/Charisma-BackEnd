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

        public DbSet<EventItem> Events { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<EventSubType> EventSubTypes { get; set; }
    }
}
