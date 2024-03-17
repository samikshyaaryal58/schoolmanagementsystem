using System.Collections.Generic;
using System.ComponentModel;

namespace schoolmanagementsystem.Models.ClassesModel
{
    public interface IClassesRepository
    {
        IEnumerable<Classes> AllClasses { get; }
        void AddClasses(Classes classes);
        Classes? GetClassesById(int classesId);
        void UpdateClasses(Classes classes);
        void DeleteClasses(int classes);
    }
}

