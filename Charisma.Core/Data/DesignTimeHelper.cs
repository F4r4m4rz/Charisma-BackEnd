using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Charisma.Core.Data
{
    public class DesignTimeHelper
    {
        public DbContextOptions Build()
        {
            DbContextOptionsBuilder temp = new DbContextOptionsBuilder();
            temp.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = CharismaDb;Integrated Security=true;");
            return temp.Options;
        }
    }
}
