using System;
using System.Collections.Generic;
using System.Linq;
using Charisma.Core.Model.Menu;
using Microsoft.EntityFrameworkCore;

namespace Charisma.Core.Data
{
    internal class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly CharismaDbContext db;
        private DbSet<TEntity> _dbSet;

        public GenericRepository(CharismaDbContext db)
        {
            this.db = db;
            _dbSet = db.Set<TEntity>();
        }

        public void Add(TEntity data)
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

        public TEntity Get(params object[] keys)
        {
            return _dbSet.Find(keys);
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

        public void Update(TEntity updatedData)
        {
            db.Entry(updatedData).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
