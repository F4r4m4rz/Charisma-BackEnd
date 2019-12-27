using System;
using System.ComponentModel.DataAnnotations;

namespace Charisma.Core.Menu
{
    public interface IMenuItem
    {
        int Id { get; }
        [Required]
        [MaxLength(50)]
        string Name { get; }
        [MaxLength(255)]
        string Description { get; }
        [Required]
        MainTypeEnum MainType { get; }
        [Required]
        SubTypeEnum SubType { get; }
        TimeSpan ApproximateWaitingTime { get; }
        double Fee { get; }
        [Required]
        bool IsAvailable { get; }
    }
}
