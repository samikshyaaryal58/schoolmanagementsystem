using Microsoft.AspNetCore.Mvc;
using schoolmanagementsystem.Models;
using schoolmanagementsystem.Models.TeacherModel;
using schoolmanagementsystem.Models.ViewModels;
namespace schoolmanagementsystem.Controllers
{
    public class TeacherController : Controller
    {

        private readonly ITeacherRepository _teacherRepository;


        public TeacherController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;

        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult TeacherList()
        {

            TeacherListViewModel teacherListViewModel = new TeacherListViewModel(_teacherRepository.AllTeacher);
            return View(teacherListViewModel);
        }

        public ActionResult AddTeacher()
        {
            var viewModel = new AddTeacherViewModel();
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddTeacher(AddTeacherViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

                Teacher newTeacher = new Teacher
                {
                    Name = viewModel.Name,
                    Picture = viewModel.Picture,
                    PhoneNumber = viewModel.PhoneNumber,
                    Subject = viewModel.Subject,
                };
                _teacherRepository.AddTeacher(newTeacher);
            }
            return View();
        }
        [HttpGet]
        public ActionResult UpdateTeacher(int id)
        {
            var teacher = _teacherRepository.GetTeacherById(id);

            var editTeacherViewModel = new UpdateTeacherViewModel
            {
                TeacherId = teacher.TeacherId,
                Name = teacher.Name,
                Picture = teacher.Picture,
                PhoneNumber = teacher.PhoneNumber,
                Subject = teacher.Subject,
            };


            return View(editTeacherViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateTeacher(UpdateTeacherViewModel model)
        {
            var teacher = _teacherRepository.GetTeacherById(model.TeacherId);

            teacher.Name = model.Name;
            teacher.Picture = model.Picture;
            teacher.PhoneNumber = model.PhoneNumber;
            teacher.Subject = model.Subject;

            _teacherRepository.UpdateTeacher(teacher);
            return RedirectToAction("TeacherList");
        }
        public IActionResult DeleteTeacher(int id)
        {

            _teacherRepository.DeleteTeacher(id);

            return RedirectToAction("TeacherList");


        }


    }
}