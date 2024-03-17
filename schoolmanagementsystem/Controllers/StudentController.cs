using Microsoft.AspNetCore.Mvc;
using schoolmanagementsystem.Models;
using schoolmanagementsystem.Models.StudentModel;
using schoolmanagementsystem.Models.ViewModels;
namespace schoolmanagementsystem.Controllers
{
    public class StudentController : Controller
    {

        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;

        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult StudentList()
        {

            StudentListViewModel studentListViewModel = new StudentListViewModel(_studentRepository.AllStudent);
            return View(studentListViewModel);
        }

        public ActionResult AddStudent()
        {
            var viewModel = new AddStudentViewModel();
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddStudent(AddStudentViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

                Student newStudent = new Student
                {
                    Name = viewModel.Name,
                    Picture = viewModel.Picture,
                    PhoneNumber = viewModel.PhoneNumber,
                    Address = viewModel.Address,
                };
                _studentRepository.AddStudent(newStudent);
            }
            return View();
        }
        [HttpGet]
        public ActionResult UpdateStudent(int id)
        {
            var student = _studentRepository.GetStudentById(id);

            var editStudentViewModel = new UpdateStudentViewModel
            {
                StudentId = student.StudentId,
                Name = student.Name,
                Picture = student.Picture,
                PhoneNumber = student.PhoneNumber,
                Address = student.Address,
            };


            return View(editStudentViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateStudent(UpdateStudentViewModel model)
        {
            var student = _studentRepository.GetStudentById(model.StudentId);

            student.Name = model.Name;
            student.Picture = model.Picture;
            student.PhoneNumber = model.PhoneNumber;
            student.Address = model.Address;

            _studentRepository.UpdateStudent(student);
            return RedirectToAction("StudentList");
        }
        public IActionResult DeleteStudent(int id)
        {

            _studentRepository.DeleteStudent(id);

            return RedirectToAction("StudentList");


        }


    }
}