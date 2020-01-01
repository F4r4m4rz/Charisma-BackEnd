using System;
using System.Collections.Generic;

namespace Charisma.Core.Data
{
    public interface ICharismaData<T1,T2>
    {
        T1 Get(params object[] keys);
        IEnumerable<T1> GetAll(Func<T1, bool> func = null);

        void Update(T1 updatedObj);
        void Delete(T2 key);
        void Delete(T1 deletedObject);
    }
}
