namespace schoolmanagementsystem.Models.ViewModels
{
    public class UpdateTeacherViewModel
    {
        public int TeacherId { get; set; }
        public string? Name { get; set; }
        public string? Picture { get; set; }
        public string? Subject { get; set; }

        public string? PhoneNumber { get; set; }
    }
}