using Charisma.Core.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace Charisma.Core.Model.Menu
{
    public class MenuItemSubType : ICharismaObject<MenuItem>
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        public MenuItemType Owner { get; set; }

        public List<MenuItem> Members { get; set; }

        public byte[] Image { get; set; }
    }
}
