using System.Collections.Generic;
using System.ComponentModel;

namespace schoolmanagementsystem.Models.TeacherModel
{
    public interface ITeacherRepository
    {
        IEnumerable<Teacher> AllTeacher { get; }
        void AddTeacher(Teacher teacher);
        Teacher? GetTeacherById(int teacherId);
        void UpdateTeacher(Teacher teacher);
        void DeleteTeacher(int student);


    }
}

