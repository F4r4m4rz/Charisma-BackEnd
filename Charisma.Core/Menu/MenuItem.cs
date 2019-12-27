using System;
namespace Charisma.Core.Menu
{
    public class MenuItem : IMenuItem
    {
        public int Id { get; set; }
        public string Name { get; set;}
        public string Description { get; set; }
        public MainTypeEnum MainType { get; set; }
        public SubTypeEnum SubType { get; set; }
        public TimeSpan ApproximateWaitingTime { get; set; }
        public double Fee { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}
