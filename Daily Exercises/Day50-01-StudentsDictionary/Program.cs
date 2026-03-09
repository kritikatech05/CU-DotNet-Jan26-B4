using System;
using System.Collections.Generic;

namespace DictionaryStudent
{
    class Student
    {
        public int StudentId { get; set; }
        public string SName { get; set; }

        public Student(int id, string name)
        {
            StudentId = id;
            SName = name;
        }

        public override bool Equals(object? obj)
        {
            Student other = obj as Student;
            if (other == null) return false;
            return this.StudentId == other.StudentId && this.SName == other.SName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(StudentId, SName);
        }
    }

    class StudentManager
    {
        public static Dictionary<Student, int> dict = new Dictionary<Student, int>();

        public static void Add(Student obj, int marks)
        {
            if (dict.ContainsKey(obj))
            {
                if (marks > dict[obj])
                {
                    dict[obj] = marks;
                }
            }
            else
            {
                dict.Add(obj, marks);
            }
        }

        public static void display()
        {
            foreach (var i in StudentManager.dict)
            {
                Console.WriteLine($"Name : {i.Key.SName}  Marks : {i.Value}");
            }

        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            StudentManager.Add(new Student(1, "kritika"), 87);
            StudentManager.Add(new Student(2, "kushagar"), 89);
            StudentManager.Add(new Student(3, "ekta"), 90);
            StudentManager.Add(new Student(4, "tushar"), 80);

            StudentManager.Add(new Student(1, "kritika"), 95);

            StudentManager.display();
        }
    }
}