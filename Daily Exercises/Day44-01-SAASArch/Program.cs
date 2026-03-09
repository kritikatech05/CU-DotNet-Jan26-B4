using System;
using System.Collections.Generic;
using System.Linq;

namespace SAASArch
{
    abstract class Subscriber : IComparable<Subscriber>
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public DateTime JoinDate { get; set; }

        public abstract decimal CalculateMonthlyBill();

        public override bool Equals(object obj)
        {
            Subscriber s = obj as Subscriber;
            if (s == null) return false;
            return this.ID == s.ID;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public int CompareTo(Subscriber other)
        {
            int result = this.JoinDate.CompareTo(other.JoinDate);

            if (result == 0)
                result = this.Name.CompareTo(other.Name);

            return result;
        }
    }

    class BusinessSubscriber : Subscriber
    {
        public decimal FixedRate { get; set; }
        public decimal TaxRate { get; set; }

        public override decimal CalculateMonthlyBill()
        {
            return FixedRate * (1 + TaxRate);
        }
    }

    class ConsumerSubscriber : Subscriber
    {
        public decimal DataUsageGB { get; set; }
        public decimal PricePerGB { get; set; }

        public override decimal CalculateMonthlyBill()
        {
            return DataUsageGB * PricePerGB;
        }
    }

    class ReportGenerator
    {
        public static void PrintRevenueReport(IEnumerable<Subscriber> subscribers)
        {
            Console.WriteLine("Revenue Report\n");

            foreach (var s in subscribers)
            {
                string type;

                if (s is BusinessSubscriber)
                    type = "Business";
                else
                    type = "Consumer";

                Console.WriteLine(
                    s.Name + " | " +
                    type + " | " +
                    s.JoinDate.ToShortDateString() + " | Bill: " +
                    s.CalculateMonthlyBill()
                );
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Dictionary<string, Subscriber> subs = new Dictionary<string, Subscriber>();

            subs.Add("kritika@saas.com", new BusinessSubscriber
            {
                ID = Guid.NewGuid(),
                Name = "Kritika",
                JoinDate = new DateTime(2023, 2, 1),
                FixedRate = 500,
                TaxRate = 0.18m
            });

            subs.Add("ks@saas.com", new BusinessSubscriber
            {
                ID = Guid.NewGuid(),
                Name = "ks",
                JoinDate = new DateTime(2022, 5, 5),
                FixedRate = 800,
                TaxRate = 0.20m
            });

            subs.Add("ravi@gmail.com", new ConsumerSubscriber
            {
                ID = Guid.NewGuid(),
                Name = "Ravi",
                JoinDate = new DateTime(2024, 1, 10),
                DataUsageGB = 120,
                PricePerGB = 2
            });

            subs.Add("ekta@gmail.com", new ConsumerSubscriber
            {
                ID = Guid.NewGuid(),
                Name = "ekta",
                JoinDate = new DateTime(2023, 11, 20),
                DataUsageGB = 60,
                PricePerGB = 3
            });

            subs.Add("kushagar@gmail.com", new ConsumerSubscriber
            {
                ID = Guid.NewGuid(),
                Name = "Kushagar",
                JoinDate = new DateTime(2022, 9, 15),
                DataUsageGB = 200,
                PricePerGB = 1.5m
            });

            var sorted = subs
                .OrderByDescending(x => x.Value.CalculateMonthlyBill())
                .Select(x => x.Value)
                .ToList();

            ReportGenerator.PrintRevenueReport(sorted);
        }
    }
}