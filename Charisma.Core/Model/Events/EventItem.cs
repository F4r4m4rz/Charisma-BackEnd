using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Charisma.Core.Model.Base;

namespace Charisma.Core.Model.Events
{
    public class EventItem : ICharismaObject
    {
        public int Id { get; set; }
        [Key, Column(Order = 0)]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        [Key, Column(Order = 1)]
        public EventType Type { get; set; }

        [Key, Column(Order = 2)]
        public EventSubType SubType { get; set; }
        public CharismaFile File_1 { get; set; }
        public CharismaFile File_2 { get; set; }
        public CharismaFile File_3 { get; set; }
        public CharismaFile File_4 { get; set; }
    }
}
