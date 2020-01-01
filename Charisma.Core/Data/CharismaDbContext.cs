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
        
        internal DbSet<IMenuItem> Menu { get; set; }
        internal DbSet<IMenuItemType> MenuItemTypes { get; set; }
        internal DbSet<IMenuItemSubType> MenuItemSubTypes { get; set; }

        internal DbSet<EventItem> Events { get; set; }
        internal DbSet<EventType> EventTypes { get; set; }
        internal DbSet<EventSubType> EventSubTypes { get; set; }
    }
}
