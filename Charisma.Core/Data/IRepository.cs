using System;
using System.Collections.Generic;
using System.Linq;

namespace Charisma.Core.Data
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll(Func<T, bool> func = null);
        IQueryable<T> GetAllQueryable();
        T Get(params object[] keys);
        void Add(T data);
        void Update(T updatedData);
        void Delete(params object[] keys);
    }
}
