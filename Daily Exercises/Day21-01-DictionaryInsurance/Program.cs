namespace DictionaryInsurance
{
    public class Policy
    {
        public string HolderName { get; set; }
        public decimal Premium { get; set; }
        public int RiskScore { get; set; }
        public DateTime RenewalDate { get; set; }

        public Policy(string holderName, decimal premium, int riskScore, DateTime renewalDate)
        {
            HolderName = holderName;
            Premium = premium;
            RiskScore = riskScore;
            RenewalDate = renewalDate;
        }

        public override string ToString()
        {
            return $"Holder: {HolderName}, Premium: {Premium}, RiskScore: {RiskScore}, Renewal: {RenewalDate.ToShortDateString()}";
        }
    }


    public class PolicyTracker
    {
        private Dictionary<string, Policy> policies = new Dictionary<string, Policy>();

        public void AddPolicy(string id, Policy policy)
        {
            policies[id] = policy;
        }

        public void BulkAdjustment()
        {
            foreach (var policy in policies.Values)
            {
                if (policy.RiskScore > 75)
                {
                    policy.Premium += policy.Premium * 0.05m;
                }
            }
        }

        public void Cleanup()
        {
            List<string> keysToRemove = new List<string>();

            foreach (var item in policies)
            {
                if (item.Value.RenewalDate < DateTime.Now.AddYears(-3))
                {
                    keysToRemove.Add(item.Key);
                }
            }

            foreach (var key in keysToRemove)
            {
                policies.Remove(key);
            }
        }

        public string GetPolicy(string id)
        {
            if (policies.TryGetValue(id, out Policy policy))
            {
                return policy.ToString();
            }
            else
            {
                return "Policy Not Found!";
            }
        }

        public void DisplayAll()
        {
            foreach (var item in policies)
            {
                Console.WriteLine($"ID: {item.Key} -> {item.Value}");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            PolicyTracker tracker = new PolicyTracker();

            tracker.AddPolicy("P101", new Policy("Amit", 10000m, 80, DateTime.Now.AddYears(-1)));
            tracker.AddPolicy("P102", new Policy("Rahul", 15000m, 60, DateTime.Now.AddYears(-4)));
            tracker.AddPolicy("P103", new Policy("Sneha", 20000m, 90, DateTime.Now));

            tracker.DisplayAll();
            tracker.BulkAdjustment();
            tracker.DisplayAll();
            tracker.Cleanup();
            tracker.DisplayAll();

            Console.WriteLine(tracker.GetPolicy("P101"));
            Console.WriteLine(tracker.GetPolicy("P999"));
        }
    }
}