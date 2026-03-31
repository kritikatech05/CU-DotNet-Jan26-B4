using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLayeredStructure.Models
{
    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Range(0, 100, ErrorMessage = "Grade must be between 0 and 100.")]
        public int Grade { get; set; }
    }
}
