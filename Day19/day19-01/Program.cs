namespace ConsoleApp1
{

    abstract class Vehicle
    {
        public string ModelName { get; set; }
        public abstract void Move();
        public virtual string GetFuelStatus()
        {
            return "Fuel level is stable.";
        }
    }

    class ElectricCar : Vehicle
    {
        public override void Move()
        {
            Console.WriteLine($"{ModelName} is gliding silently on battery power");
        }
        public override string GetFuelStatus()
        {
            return $"{ModelName} battery is at 80%";
        }
    }
    class HeavyTruck : Vehicle
    {
        public override void Move()
        {
            Console.WriteLine($"{ModelName} is hauling cargo with high-torque diesel power.");
        }

    }
    //kritika sharma
    class CargoPlane : Vehicle
    {
        public override void Move()
        {
            Console.WriteLine($"{ModelName} is ascending to 30,000 feet");
        }
        public override string GetFuelStatus()
        {
            return base.GetFuelStatus() + $" Checking jet fuel reserves...";
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicle[] arr =
            {
                new ElectricCar { ModelName = "lamborghini" },
                new HeavyTruck { ModelName = "bmw" },
                new CargoPlane { ModelName = "thar" }
            };

            foreach (Vehicle v in arr)
            {
                v.Move();
                Console.WriteLine(v.GetFuelStatus());
                Console.WriteLine();
            }
        }
    }
}
