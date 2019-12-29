﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Charisma.Core.Model.Base;
using Microsoft.EntityFrameworkCore;

namespace Charisma.Core.Model.Menu
{
    public class MenuItem : ICharismaObject
    {
        [Key, Column(Order =0)]
        [MaxLength(50)]
        public string Name { get; set;}

        [MaxLength(255)]
        public string Description { get; set; }

        [Key, Column(Order = 1)]
        public MenuItemType Type { get; set; }

        [Key, Column(Order = 2)]
        public MenuItemSubType SubType { get; set; }

        public MenuItemRecipe Recipe { get; set; }
        public TimeSpan ApproximateWaitingTime { get; set; }
        public double Fee { get; set; }
        public bool IsAvailable { get; set; } = true;
        public CharismaFile File_1 { get; set; }
        public CharismaFile File_2 { get; set; }
        public CharismaFile File_3 { get; set; }
        public CharismaFile File_4 { get; set; }

        [NotMapped]
        public IEnumerable<Ingredient> Ingredients
        {
            get
            {
                return Recipe.Ingredients;
            }
        }

        [NotMapped]
        public IEnumerable<Allergies> Allergies
        {
            get
            {
                return Recipe.Allergies;
            }
        }
    }
}