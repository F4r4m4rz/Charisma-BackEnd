using System;
using System.Collections.Generic;
using Charisma.Core.Menu;

namespace Charisma.Data.Data
{
    public interface ICharismaData
    {
        IEnumerable<IMenuItem> GetAll(Func<IMenuItem, bool> func = null);
        IMenuItem GetById(int id);
    }
}
