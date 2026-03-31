using StudentLayeredStructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLayeredStructure.Repositories
{
    internal class ListStudentRepository : IStudentRepository
    {
        private List<Student> students = new List<Student>();
        void IStudentRepository.AddStudent(Student student)
        {
             if (student.Id == 0 || students.Any(s => s.Id == student.Id))
            {
                var nextId = students.Any() ? students.Max(s => s.Id) + 1 : 1;
                student.Id = nextId;
            }
            students .Add(student);
        }

        void IStudentRepository.deleteStudent(int id)
        {
            var st = students.FirstOrDefault(s => s.Id == id);
            students.Remove(st);

        }

        void IStudentRepository.UpdateStudent(Student student)
        {
            //var stu=student.Id;
            var check=students.FirstOrDefault(s => s.Id == student.Id);
            if (check != null)
            {
                check.Name = student.Name;
                check.Grade = student.Grade;
            }

        }
         List<Student> IStudentRepository.Get()
        {
            //foreach (var student in students)
            //{
            //    Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Grade: {student.Grade}");
            //}
            return students;
        }   
    }
}
