using Charisma.Core.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Charisma.Core.Model.Menu
{
    public class Ingredient : ICharismaObject<Ingredient>
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public byte[] Image { get; set; }

        public MenuItem MenuItem { get; set; }

        [NotMapped]
        public List<Ingredient> Members { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
