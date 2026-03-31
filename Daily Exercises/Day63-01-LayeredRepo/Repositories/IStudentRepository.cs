using StudentLayeredStructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLayeredStructure.Repositories
{
    internal interface IStudentRepository
    {
        void AddStudent(Student student);
        void UpdateStudent(Student student);
        void deleteStudent(int id);
        List<Student> Get();
    }
}
