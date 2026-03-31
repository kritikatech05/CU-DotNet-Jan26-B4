using StudentLayeredStructure.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace StudentLayeredStructure.Repositories
{
    internal class JsonStudentRepository : IStudentRepository
    {
        private string path = @"../../../student.json";
        private readonly JsonSerializerOptions jsonOptions = new JsonSerializerOptions { WriteIndented = true };

        void IStudentRepository.AddStudent(Student student)
        {
            var students = ReadAll();
            if (student.Id == 0 || students.Any(s => s.Id == student.Id))
            {
                var nextId = students.Any() ? students.Max(s => s.Id) + 1 : 1;
                student.Id = nextId;
            }

            students.Add(student);
            WriteAll(students);
        }

        void IStudentRepository.deleteStudent(int id)
        {
            //var read =JsonSerializer.Deserialize<List<Student>>(File.ReadAllText(path));
            var students = ReadAll();
            var existing = students.FirstOrDefault(s => s.Id == id);
            if (existing != null)
            {
                students.Remove(existing);
                WriteAll(students);
            }
        }

        List<Student> IStudentRepository.Get()
        {
            return ReadAll();
        }

        void IStudentRepository.UpdateStudent(Student student)
        {
            var students = ReadAll();
            var existing = students.FirstOrDefault(s => s.Id == student.Id);
            if (existing == null)
            {
                return;
            }

            existing.Name = student.Name;
            existing.Grade = student.Grade;
            WriteAll(students);
        }

        private List<Student> ReadAll()
        {
            try
            {
                if (!File.Exists(path))
                {
                    var dir = Path.GetDirectoryName(path);
                    if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }

                    File.WriteAllText(path,"");
                    return new List<Student>();
                }

                var json = File.ReadAllText(path);
                if (string.IsNullOrWhiteSpace(json))
                {
                    return new List<Student>();
                }

                var students = JsonSerializer.Deserialize<List<Student>>(json);
                if (students != null)
                {

                return students;
                }
                return new List<Student>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void WriteAll(List<Student> students)
        {
            try
            {
                var json = JsonSerializer.Serialize(students, jsonOptions);
                File.WriteAllText(path, json);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
