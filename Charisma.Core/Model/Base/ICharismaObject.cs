using System;
namespace Charisma.Core.Model.Base
{
    public interface ICharismaObject
    {
        string Name { get; set; }
        string Description { get; set; }
        CharismaFile File_1 { get; set; }
        CharismaFile File_2 { get; set; }
        CharismaFile File_3 { get; set; }
        CharismaFile File_4 { get; set; }
    }
}
