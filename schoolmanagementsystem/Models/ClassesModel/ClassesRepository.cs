using Microsoft.EntityFrameworkCore;


using schoolmanagementsystem.Models;

namespace schoolmanagementsystem.Models.ClassesModel
{
    public class ClassesRepository : IClassesRepository
    {

        private readonly SchoolManagementSystemDbContext _schoolManagementDbContext;

        public ClassesRepository(SchoolManagementSystemDbContext schoolManagementDbContext)
        {

            _schoolManagementDbContext = schoolManagementDbContext;
        }

        public IEnumerable<Classes> AllClasses
        {
            get
            {
                return _schoolManagementDbContext.Classes;
            }
        }


        public void AddClasses(Classes classes)
        {

            _schoolManagementDbContext.Classes.Add(classes);
            _schoolManagementDbContext.SaveChanges();
        }


        public Classes? GetClassesById(int classesId)
        {

            return _schoolManagementDbContext.Classes.FirstOrDefault(p => p.ClassesId == classesId);
        }

        public void UpdateClasses(Classes classes)
        {

            var existingClasses = _schoolManagementDbContext.Classes.FirstOrDefault(p => p.ClassesId == classes.ClassesId);
            if (existingClasses == null)
            {
                throw new ArgumentException("Classes not found");
            }


            existingClasses.ClassesId = classes.ClassesId;
            existingClasses.Name = classes.Name;
            existingClasses.Section = classes.Section;

            _schoolManagementDbContext.Entry(existingClasses).State = EntityState.Modified;
            _schoolManagementDbContext.SaveChanges();
        }

        public void DeleteClasses(int id)
        {

            var classes = _schoolManagementDbContext.Classes.Find(id);

            if (classes == null)
            {
                throw new ArgumentException("Classes not found");
            }


            _schoolManagementDbContext.Classes.Remove(classes);
            _schoolManagementDbContext.SaveChanges();

        }
    }
}