using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Charisma.Core.Model.Base;
using Microsoft.EntityFrameworkCore;

namespace Charisma.Core.Model.Menu
{
    public class MenuItem
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        public MenuItemType Type { get; set; }

        [Required]
        public MenuItemSubType SubType { get; set; }

        public Recipe Recipe { get; set; }
    }
}
