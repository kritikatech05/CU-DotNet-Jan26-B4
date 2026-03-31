using StudentLayeredStructure.Models;
using StudentLayeredStructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentLayeredStructure.Services
{
    internal class StudentService
    {
        private readonly IStudentRepository repository;

        public StudentService(IStudentRepository repository)
        {
            this.repository = repository;
        }

        public void AddStudent(Student student)
        {
            if (student == null) throw new ArgumentNullException(nameof(student));
            if (student.Grade < 0 || student.Grade > 100)
                throw new ArgumentOutOfRangeException(nameof(student.Grade), "Grade must be between 0 and 100.");

            repository.AddStudent(student);
        }

        public List<Student> GetAllStudents()
        {
            return repository.Get();
        }

        public void UpdateStudent(Student student)
        {
            if (student == null) throw new ArgumentNullException(nameof(student));
            repository.UpdateStudent(student);
        }

        public void DeleteStudent(int id)
        {
            repository.deleteStudent(id);
        }

        public Student GetStudentById(int id)
        {
            return repository.Get().FirstOrDefault(s => s.Id == id);
        }
    }
}