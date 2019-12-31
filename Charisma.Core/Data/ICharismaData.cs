using System;
using System.Collections.Generic;

namespace Charisma.Core.Data
{
    public interface ICharismaData<T>
    {
        T Get(params object[] keys);
        IEnumerable<T> GetAll(Func<T, bool> func = null);

        void Update(T updatedObj);
        void Delete(params object[] keys);
        void Delete(T deletedObject);
    }
}
