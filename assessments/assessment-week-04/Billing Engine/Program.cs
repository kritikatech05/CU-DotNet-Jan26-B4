using System.Numerics;
using System.Text;

namespace Billing_Engine
{


    class Patient
    {
        public string Name { get; set; }
        public decimal BaseFee { get; set; }

        public Patient(string name, decimal basefee)
        {
            Name = name;
            BaseFee = basefee;

        }
        public virtual decimal CalculateFinalBill()
        {
            return BaseFee;
        }
    }

    class InPatient : Patient
    {
        public int DayStayed { get; set; }
        public decimal DailyRate { get; set; }

        public InPatient(string name, decimal basefee, int days, decimal rate) : base(name, basefee)
        {
            DayStayed = days;
            DailyRate = rate;
        }
        public override decimal CalculateFinalBill()
        {
            decimal total = BaseFee;
            total += DayStayed * DailyRate;
            return total;
        }
    }

    class OutPatient : Patient
    {
        public decimal ProcedureFee { get; set; }
        public OutPatient(string name, decimal basefee, decimal Pfee) : base(name, basefee)
        {
            ProcedureFee = Pfee;
        }
        public override decimal CalculateFinalBill()
        {
            decimal total = BaseFee;
            total += ProcedureFee;
            return total;
        }
    }

    class EmergencyPatient : Patient
    {
        public int SeverityLevel { get; set; }
        public EmergencyPatient(string name, decimal basefee, int slevel) : base(name, basefee)
        {
            SeverityLevel = slevel;
        }
        public override decimal CalculateFinalBill()
        {
            return (BaseFee * SeverityLevel);

        }
    }


    class HospitalBilling
    {
        List<Patient> patients = new List<Patient>();

        public void AddPatient(Patient p)
        {
            patients.Add(p);
        }
        public void GenerateDailyReport()
        {
            Console.WriteLine("-------DAILY REPORT-------");
            foreach (Patient p in patients)
            {
                decimal bill = p.CalculateFinalBill();
                Console.WriteLine($"Name of patient : {p.Name} \ntotal bill : {bill.ToString("C2")}");

                Console.WriteLine();
            }


        }

        public decimal CalculateTotalRevenue()
        {
            decimal total = 0;
            foreach (Patient p in patients)
            {
                total += p.CalculateFinalBill();

            }
            return total;
        }

        public int GetInPatientCount()
        {
            int count = 0;
            foreach (Patient p in patients)
            {
                if (p is InPatient)
                {
                    count++;
                }
            }
            return count;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            HospitalBilling obj = new HospitalBilling();
            decimal bfee = 1000m;
            obj.AddPatient(new InPatient("ria", bfee, 7, 100m));
            obj.AddPatient(new EmergencyPatient("sk", bfee, 3));
            obj.AddPatient(new InPatient("harshit", bfee, 3, 100m));
            obj.AddPatient(new OutPatient("hero", bfee, 500m));

            
            obj.GenerateDailyReport();
            Console.WriteLine("------TOTAL REVENUE------");
            Console.WriteLine();
            Console.WriteLine($"total revenue : {obj.CalculateTotalRevenue().ToString("C2")}");
            Console.WriteLine();
            Console.WriteLine("-----TOTAL INPATIENTS-----");
            Console.WriteLine();
            Console.WriteLine($"total inpatients : {obj.GetInPatientCount()}");
            Console.WriteLine();

        }
    }
}
