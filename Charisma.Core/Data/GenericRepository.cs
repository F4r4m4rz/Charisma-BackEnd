using System;
using System.Collections.Generic;
using System.Linq;
using Charisma.Core.Model.Menu;
using Microsoft.EntityFrameworkCore;

namespace Charisma.Core.Data
{
    internal class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly CharismaDbContext db;
        private DbSet<T> _dbSet;

        public GenericRepository(CharismaDbContext db)
        {
            this.db = db;

        }

        public void Add(T data)
        {
            _dbSet.Add(data);
            db.SaveChanges();
        }

        public void Delete(params object[] keys)
        {
            var obj = Get(keys);

            if (obj != null)
            {
                _dbSet.Remove(obj);
                db.SaveChanges();
            }
        }

        public T Get(params object[] keys)
        {
            return _dbSet.Find(keys);
        }

        public IEnumerable<T> GetAll(Func<T, bool> func = null)
        {
            if (func == null)
            {
                return _dbSet.ToList();
            }

            return _dbSet.Where(func);
        }

        public IQueryable<T> GetAllQueryable()
        {
            return _dbSet;
        }

        public void Update(T updatedData)
        {
            db.Entry(updatedData).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
