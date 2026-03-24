using Annual_Performance;

namespace TestBonusCalculation
{
    public class Tests
    {
        EmployeeBonus employee;
        [SetUp]
        public void Setup()
        {
            employee = new EmployeeBonus();
           
        }

        [Test]
        public void NormalHighPerformer()
        {
            employee.BaseSalary = 500000m;
            employee.PerformanceRating = 5;
            employee.YearsOfExperience = 6;
            employee.DepartmentMultiplier = 1.1m;
            employee.AttendancePercentage = 95;

            Assert.AreEqual(123200.00m, employee.NetAnnualBonus);
        }
        [Test]
        public void AttendancePenalty()
        {
            employee.BaseSalary = 400000;
            employee.PerformanceRating = 4;
            employee.YearsOfExperience = 8;
            employee.DepartmentMultiplier = 1.0m;
            employee.AttendancePercentage = 80;
            Assert.AreEqual(60480.00m, employee.NetAnnualBonus);
        }

        [Test]
        public void CapTriggered()
        {
            employee.BaseSalary = 1000000;
            employee.PerformanceRating = 5;
            employee.YearsOfExperience = 15;
            employee.DepartmentMultiplier = 1.5m;
            employee.AttendancePercentage = 95;
            Assert.AreEqual(280000.00m, employee.NetAnnualBonus);
        }

        [Test]
        public void ZeroSalary()
        {
            employee.BaseSalary = 0;
            
            Assert.AreEqual(0.00m, employee.NetAnnualBonus);
        }

        [Test]
        public void LowPerformer()
        {
            employee.BaseSalary = 300000m;
            employee.PerformanceRating = 2;
            employee.YearsOfExperience = 3;
            employee.DepartmentMultiplier = 1.0m;
            employee.AttendancePercentage = 90;

            Assert.AreEqual(13500.00m, employee.NetAnnualBonus);
        }

        [Test]
        public void TaxBoundary()
        {
            employee.BaseSalary = 600000m;
            employee.PerformanceRating = 3;
            employee.YearsOfExperience = 0;
            employee.DepartmentMultiplier = 1.0m;
            employee.AttendancePercentage = 100;

            Assert.AreEqual(64800.00m, employee.NetAnnualBonus);
        }

        [Test]
        public void HighTaxSlab()
        {
            employee.BaseSalary = 900000m;
            employee.PerformanceRating = 5;
            employee.YearsOfExperience = 11;
            employee.DepartmentMultiplier = 1.2m;
            employee.AttendancePercentage = 100;

            Assert.AreEqual(226800.00m, employee.NetAnnualBonus);
        }

        [Test]
        public void Precision_Rounding()
        {
            employee.BaseSalary = 555555m;
            employee.PerformanceRating = 4;
            employee.YearsOfExperience = 6;
            employee.DepartmentMultiplier = 1.13m;
            employee.AttendancePercentage = 92;

            Assert.AreEqual(118649.88m, employee.NetAnnualBonus);
        }

        [Test]
        public void InvalidRating()
        {
            employee.BaseSalary = 500000m;
            employee.PerformanceRating = 7; 
            employee.YearsOfExperience = 5;
            employee.DepartmentMultiplier = 1.0m;
            employee.AttendancePercentage = 90;

            Assert.Throws<InvalidOperationException>(() =>
            {
                var result = employee.NetAnnualBonus;
            });
        }

    }
}