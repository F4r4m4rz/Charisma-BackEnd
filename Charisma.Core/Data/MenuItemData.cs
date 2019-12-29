using System;
using System.Collections.Generic;
using System.Linq;
using Charisma.Core.Model.Menu;

namespace Charisma.Core.Data
{
    public class MenuItemData : ICharismaData<MenuItem>
    {
        private readonly CharismaDbContext db;

        public MenuItemData(CharismaDbContext db)
        {
            this.db = db;
        }

        public void Add(MenuItem data)
        {
            db.Menu.Add(data);
            db.SaveChanges();
        }

        public void Delete(params object[] keys)
        {
            var obj = Get(keys);

            if (obj != null)
            {
                db.Menu.Remove(obj);
                db.SaveChanges();
            }
        }

        public MenuItem Get(params object[] keys)
        {
            return db.Menu.Find(keys);
        }

        public IEnumerable<MenuItem> GetAll(Func<MenuItem, bool> func = null)
        {
            if (func == null)
            {
                return db.Menu;
            }

            return db.Menu.Where(func);
        }

        public void Update(MenuItem updatedData)
        {
            var obj = Get(updatedData.Name, updatedData.Type, updatedData.SubType);
            Tools.MatchUpObjects(updatedData, obj);
            db.SaveChanges();
        }
    }
}
