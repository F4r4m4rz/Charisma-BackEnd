using System;
using System.Collections.Generic;

namespace Charisma.Core.Model.Base
{
    public interface ICharismaObject<T>
    {
        int Id { get; set; }
        List<T> Members { get; set; }
    }
}
