namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Order o1 = new Order(1, "Kritika");
            o1.AddItem(20);
            o1.AddItem(30);
            o1.ApplyDiscount(10);
            o1.ApplyDiscount(20);

            Console.WriteLine(o1.GetOrderSummary());

            Order o2 = new Order();
            o2.CustomerName = "kartik";
            o2.AddItem(100);
            o2.AddItem(250);

            Console.WriteLine(o2.GetOrderSummary());
        }
    }

    class Order
    {
        
        private int orderId;
        private string customerName;
        private decimal totalAmount; 
        private DateTime orderDate;
        private string status;
        private bool discountApplied;

        public Order()
        {
            orderDate = DateTime.Now;
            status = "NEW";
            totalAmount = 0;
            discountApplied = false;
        }

  
        public Order(int Id, string Name)
        {
            orderId = Id;
            customerName = Name;
            orderDate = DateTime.Now;
            status = "NEW";
            totalAmount = 0;
            discountApplied = false;
        }

        public int OrderId
        {
            get { return orderId; }
        }

  
        public string CustomerName
        {
            get { return customerName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Customer name cannot be empty!");
                }
                else
                {
                    customerName = value;
                }
            }
        }

        public decimal TotalAmount
        {
            get { return totalAmount; }
        }

        public void AddItem(decimal price)
        {
            if (price <= 0)
            {
                Console.WriteLine("Item price must be greater than zero.");
                return;
            }

            totalAmount += price;
        }

        public void ApplyDiscount(decimal percentage)
        {
            if (discountApplied)
            {
                Console.WriteLine("Discount already applied!");
                return;
            }

            if (percentage < 1 || percentage > 30)
            {
                Console.WriteLine("Discount must be between 1 and 30%");
                return;
            }

            decimal discountAmount = totalAmount * (percentage / 100);
            totalAmount -= discountAmount;

            if (totalAmount < 0)
                totalAmount = 0;

            discountApplied = true;
        }
        public string GetOrderSummary()
        {
            return $"Order Id: {orderId}," +
                $" Customer: {customerName}," +
                $" Total Amount: {totalAmount}," +
                $" Status: {status}";
        }

    }
}




