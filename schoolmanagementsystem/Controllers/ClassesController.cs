using Microsoft.AspNetCore.Mvc;

using schoolmanagementsystem.Models;
using schoolmanagementsystem.Models.ClassesModel;
using schoolmanagementsystem.Models.ClassesViewModels;
using schoolmanagementsystem.Models.ViewModels;
namespace School_Management_System.Controllers
{
    public class ClassesController : Controller
    {
        private readonly IClassesRepository _classesRepository;
        public ClassesController(IClassesRepository classesRepository)
        {
            _classesRepository = classesRepository;

        }

        public IActionResult Index()
        {
            return View();
        }




        [HttpGet]
        public IActionResult ClassesList()
        {

            ClassesListViewModel classesListViewModel = new ClassesListViewModel(_classesRepository.AllClasses);
            return View(classesListViewModel);
        }

        public ActionResult AddClasses()
        {
            var viewModel = new AddClassesViewModel();
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddClasses(AddClassesViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

                Classes newClasses = new Classes
                {
                    Name = viewModel.Name,
                    Section = viewModel.Section

                };
                _classesRepository.AddClasses(newClasses);
            }
            return RedirectToAction("ClassesList");
        }


        [HttpGet]
        public ActionResult UpdateClasses(int id)
        {
            var classes = _classesRepository.GetClassesById(id);

            var editClassesViewModel = new UpdateClassesViewModels
            {
                ClassesId = classes.ClassesId,
                Name = classes.Name,
                Section = classes.Section,

            };


            return View(editClassesViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateClasses(UpdateClassesViewModels model)
        {
            var classes = _classesRepository.GetClassesById(model.ClassesId);

            classes.Name = model.Name;
            classes.Section = model.Section;


            _classesRepository.UpdateClasses(classes);
            return RedirectToAction("CLassesList");
        }

        public IActionResult DeleteClasses(int id)
        {

            _classesRepository.DeleteClasses(id);

            return RedirectToAction("ClassesList");


        }
    }
}