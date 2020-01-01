using System;
using System.Collections.Generic;
using Charisma.Core.Model.Menu;

namespace Charisma.Menu.Model
{
    public class MenuItemData : ICharismaData<MenuItem, int>
    {
        private readonly IRepository<MenuItem> repository;

        public MenuItemData(IRepository<MenuItem> repository)
        {
            this.repository = repository;
        }
    }
}
