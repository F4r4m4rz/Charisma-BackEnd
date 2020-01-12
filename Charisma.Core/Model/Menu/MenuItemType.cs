using Charisma.Core.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Charisma.Core.Model.Menu
{
    public class MenuItemType : ICharismaObject<MenuItemSubType>
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }

        public List<MenuItemSubType> Members { get; set; }

        public byte[] Image { get; set; }
    }
}
