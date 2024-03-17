namespace schoolmanagementsystem.Models.ViewModels
{
    public class TeacherListViewModel
    {
        public IEnumerable<Teacher> Teachers { get; }

        public TeacherListViewModel(IEnumerable<Teacher> teachers)
        {

            Teachers = teachers;
        }
    }
}