using System;
namespace Charisma.Core.Model.Base
{
    public class CharismaFile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] File { get; set; }
    }
}
