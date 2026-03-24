using System;

namespace Annual_Performance
{
    public class EmployeeBonus
    {
        public decimal BaseSalary { get; set; }
        public int PerformanceRating { get; set; }
        public int YearsOfExperience { get; set; }
        public decimal DepartmentMultiplier { get; set; }
        public double AttendancePercentage { get; set; }

        public decimal NetAnnualBonus
        {
            get
            {
                if (BaseSalary <= 0)
                    return 0;

                if (PerformanceRating < 1 || PerformanceRating > 5)
                    throw new InvalidOperationException("Performance Rating must be between 1 - 5");

                decimal ratingPercent = 0;

                if (PerformanceRating == 5) ratingPercent = 0.25m;
                else if (PerformanceRating == 4) ratingPercent = 0.18m;
                else if (PerformanceRating == 3) ratingPercent = 0.12m;
                else if (PerformanceRating == 2) ratingPercent = 0.05m;
                else ratingPercent = 0.00m;

                decimal bonus = BaseSalary * ratingPercent;

                if (YearsOfExperience > 10)
                    bonus += BaseSalary * 0.05m;
                else if (YearsOfExperience > 5)
                    bonus += BaseSalary * 0.03m;

                if (AttendancePercentage < 85)
                    bonus -= bonus * 0.20m;

                bonus *= DepartmentMultiplier;

                decimal maxBonus = BaseSalary * 0.40m;
                if (bonus > maxBonus)
                    bonus = maxBonus;

                if (bonus <= 150000)
                    bonus -= bonus * 0.10m;
                else if (bonus <= 300000)
                    bonus -= bonus * 0.20m;
                else
                    bonus -= bonus * 0.30m;

                return Math.Round(bonus, 2);
            }
        }
    }
}