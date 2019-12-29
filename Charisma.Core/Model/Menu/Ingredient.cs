using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Charisma.Core.Model.Base;

namespace Charisma.Core.Model.Menu
{
    public class Ingredient : ICharismaObject
    {
        [Key]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }
        public virtual IEnumerable<Allergies> Allergies { get; set; }
        public double Callories { get; set; }
        public CharismaFile File_1 { get; set; }
        public CharismaFile File_2 { get; set; }
        public CharismaFile File_3 { get; set; }
        public CharismaFile File_4 { get; set; }
    }
}
