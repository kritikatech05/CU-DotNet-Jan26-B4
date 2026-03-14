using Microsoft.AspNetCore.Mvc;
using Pulse.Models;

namespace Pulse.Controllers
{
    public class ComapnyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            List<Employee> emp = new List<Employee>
            {
                 new Employee{ Id=1, Name="Kritika Sharma", Position="Software Engineer", Salary=60000 },
                new Employee{ Id=2, Name="Ekta Mall", Position="UI Designer", Salary=55000 },
                new Employee{ Id=3, Name="Kushagar", Position="Project Manager", Salary=65000 },
                new Employee{ Id=4, Name="Tushar Sharma", Position="QA Analyst", Salary=50000 }
            };

            ViewBag.Announcement = "you guys got 10% hike yayyyy!!";

            ViewData["DepartmentName"] = "IT";
            ViewData["ServerStatus"] = true;

            return View(emp);
        }
    }


}
