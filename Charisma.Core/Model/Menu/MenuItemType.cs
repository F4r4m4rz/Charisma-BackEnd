using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Charisma.Core.Model.Base;

namespace Charisma.Core.Model.Menu
{
    public class MenuItemType : ICharismaObject
    {
        [Key]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public virtual IEnumerable<MenuItemSubType> SubTypes { get; set; }
        public CharismaFile File_1 { get; set; }
        public CharismaFile File_2 { get; set; }
        public CharismaFile File_3 { get; set; }
        public CharismaFile File_4 { get; set; }
    }
}