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
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        [Range(0, double.MaxValue)]
        public double Fee { get; set; }

        public TimeSpan WaitingTime { get; set; }

        public bool IsAvailable { get; set; }

        public Recipe Recipe { get; set; }

        [NotMapped]
        public MenuItemType Type { get => SubType.Owner; }

        [Required]
        public MenuItemSubType SubType { get; set; }

        [NotMapped]
        public List<Ingredient> Ingredients { get => Recipe.Ingredients; }

        public byte[] Image { get; set; }
    }
}
