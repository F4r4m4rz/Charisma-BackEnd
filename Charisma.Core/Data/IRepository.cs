using Charisma.Core.Model.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Charisma.Core.Data
{
    public interface IRepository<T> where T : ICharismaObject
    {
        IEnumerable<T> GetAll(Func<T, bool> func = null);
        IQueryable<T> GetAllQueryable();
        T Get(int key);
        IQueryable<T> GetFull(params string[] properties);
        void Add(T data);
        void Update(T updatedData);
        void Delete(int key);
    }
}
