using Charisma.Core.Model.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Charisma.Core.Model.Menu
{
    public class Ingredient : ICharismaObject
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public Recipe Recipe { get; set; }

        public byte[] Image { get; set; }
    }
}
