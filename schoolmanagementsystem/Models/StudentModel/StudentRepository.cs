using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.IO.Pipelines;

namespace schoolmanagementsystem.Models.StudentModel
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolManagementSystemDbContext _schoolManagementDbContext;

        public StudentRepository(SchoolManagementSystemDbContext schoolManagementDbContext)
        {

            _schoolManagementDbContext = schoolManagementDbContext;
        }

        public IEnumerable<Student> AllStudent
        {
            get
            {
                return _schoolManagementDbContext.Students;
            }
        }


        public void AddStudent(Student student)
        {

            _schoolManagementDbContext.Students.Add(student);
            _schoolManagementDbContext.SaveChanges();
        }


        public Student? GetStudentById(int studentId)
        {

            return _schoolManagementDbContext.Students.FirstOrDefault(p => p.StudentId == studentId);
        }

        public void UpdateStudent(Student student)
        {

            var existingStudent = _schoolManagementDbContext.Students.FirstOrDefault(p => p.StudentId == student.StudentId);
            if (existingStudent == null)
            {
                throw new ArgumentException("student not found");
            }


            existingStudent.Name = student.Name;
            existingStudent.Picture = student.Picture;
            existingStudent.PhoneNumber = student.PhoneNumber;
            existingStudent.Address = student.Address;

            _schoolManagementDbContext.Entry(existingStudent).State = EntityState.Modified;
            _schoolManagementDbContext.SaveChanges();
        }

        public void DeleteStudent(int id)
        {

            var student = _schoolManagementDbContext.Students.Find(id);

            if (student == null)
            {
                throw new ArgumentException("student not found");
            }


            _schoolManagementDbContext.Students.Remove(student);
            _schoolManagementDbContext.SaveChanges();

        }
    }
}