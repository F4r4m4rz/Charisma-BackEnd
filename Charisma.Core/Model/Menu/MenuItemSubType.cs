using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Charisma.Core.Model.Base;

namespace Charisma.Core.Model.Menu
{
    public class MenuItemSubType : ICharismaObject
    {
        [Key, Column(Order = 0)]
        public string Name { get; set; }
        public string Description { get; set; }

        [Key, Column(Order = 1)]
        public MenuItemType Type { get; set; }
        public virtual IEnumerable<MenuItem> MenuItems { get; set; }
        public CharismaFile File_1 { get; set; }
        public CharismaFile File_2 { get; set; }
        public CharismaFile File_3 { get; set; }
        public CharismaFile File_4 { get; set; }

    }
}