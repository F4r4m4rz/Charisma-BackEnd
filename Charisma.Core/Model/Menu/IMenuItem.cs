using System;
using System.ComponentModel.DataAnnotations;

namespace Charisma.Core.Model.Menu
{
    public interface IMenuItem
    {
        int Id { get; set; }

        [Required]
        [MaxLength(50)]
        string Name { get; set; }

        [MaxLength(255)]
        string Description { get; set; }

        [Required]
        MainTypeEnum MainType { get; set; }

        [Required]
        SubTypeEnum SubType { get; set; }

        TimeSpan ApproximateWaitingTime { get; set; }
        double Fee { get; set; }
        bool IsAvailable { get; set; }
    }
}
