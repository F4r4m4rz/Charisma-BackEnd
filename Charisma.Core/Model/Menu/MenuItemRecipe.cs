using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Charisma.Core.Model.Base;

namespace Charisma.Core.Model.Menu
{
    public class MenuItemRecipe : ICharismaObject
    {
        [Key, Column(Order =0)]
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual IEnumerable<Ingredient> Ingredients { get; set; }
        public CharismaFile File_1 { get; set; }
        public CharismaFile File_2 { get; set; }
        public CharismaFile File_3 { get; set; }
        public CharismaFile File_4 { get; set; }

        [NotMapped]
        public IEnumerable<Allergies> Allergies
        {
            get
            {
                List<Allergies> allergies = new List<Allergies>();
                foreach (var item in Ingredients)
                {
                    allergies.AddRange(item.Allergies);
                }
                return allergies;
            }
        }
    }
}