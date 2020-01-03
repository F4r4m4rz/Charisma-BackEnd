using System;
using System.Collections.Generic;
using System.Linq;
using Charisma.Core.Model.Base;
using Charisma.Core.Model.Menu;
using Microsoft.EntityFrameworkCore;

namespace Charisma.Core.Data
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class, ICharismaObject
    {
        private readonly DbContext db;
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
                return _dbSet.AsNoTracking().ToList();
            }

            return _dbSet.AsNoTracking().Where(func);
        }

        public IQueryable<TEntity> GetAllQueryable()
        {
            return _dbSet.AsNoTracking();
        }

        public IQueryable<TEntity> GetFull(params string[] properties)
        {
            var set = GetAllQueryable();

            foreach (var property in properties)
            {
                set = set.Include(property);
            }

            return set.AsTracking();
        }

        public void Update(TEntity updatedData)
        {
            var local = _dbSet.Local.FirstOrDefault(c => c.Id == updatedData.Id);

            if (local != null)
            {
                db.Entry(local).State = EntityState.Detached;
            }

            db.Entry(updatedData).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
