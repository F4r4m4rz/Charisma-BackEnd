using System;
namespace Charisma.Core.Model.Base
{
    public interface ICharismaObject
    {
        int Id { get; set; }
        string Description { get; set; }
        ICharismaFile File_1 { get; set; }
        ICharismaFile File_2 { get; set; }
        ICharismaFile File_3 { get; set; }
        ICharismaFile File_4 { get; set; }
    }
}
