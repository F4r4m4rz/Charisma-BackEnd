using System;
using System.Collections.Generic;
using System.Linq;
using Charisma.Core.Model.Base;
using Charisma.Core.Model.Menu;
using Microsoft.EntityFrameworkCore;

namespace Charisma.Core.Data
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public readonly DbContext db;
        private DbSet<TEntity> _dbSet;

        public GenericRepository(DbContext db)
        {
            this.db = db;
            _dbSet = db.Set<TEntity>();
        }

        public void Add(TEntity data)
        {
            _dbSet.Add(data);
            db.SaveChanges();
        }

        public void Delete(int key)
        {
            var obj = Get(key);

            if (obj != null)
            {
                _dbSet.Remove(obj);
                db.SaveChanges();
            }
        }

        public TEntity Get(int key)
        {
            return _dbSet.Find(key);
        }

        public IEnumerable<TEntity> GetAll(Func<TEntity, bool> func = null)
        {
            if (func == null)
            {
                return _dbSet.ToList();
            }

            return _dbSet.Where(func);
        }

        public IQueryable<TEntity> GetAllQueryable()
        {
            return _dbSet;
        }

        public IQueryable<TEntity> GetFull(params string[] properties)
        {
            var set = GetAllQueryable();

            foreach (var property in properties)
            {
                set = set.Include(property);
            }

            return set;
        }

        public void Update(TEntity updatedData)
        {
            db.Entry(updatedData).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
