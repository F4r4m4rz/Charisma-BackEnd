using System;
using System.Collections.Generic;

namespace Charisma.Core.Data
{
    public interface ICharismaData<T>
    {
        IEnumerable<T> GetAll(Func<T, bool> func = null);
        T Get(params object[] keys);
        void Add(T data);
        void Update(T updatedData);
        void Delete(params object[] keys);
    }
}
