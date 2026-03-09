namespace Cargo_Manifest_Optimizer
{
    class Item
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public string Category { get; set; }

        public Item(string name, double weight, string category)
        {
            Name = name;
            Weight = weight;
            Category = category;
        }
    }

    class Container
    {
        public string ContainerID { get; set; }
        public List<Item> Items = new List<Item>();
        public Container(string CId, List<Item> item)
        {
            ContainerID = CId;
            if (Items != null)
                Items = item;
            else
                Items = new List<Item>();
        }
        
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            

            var cargoBay = new List<List<Container>>
            {
                // ROW 0: High-Value Tech Row
                new List<Container>
                {
                    new Container("C001", new List<Item>
                    {
                        new Item("Laptop", 2.5, "Tech"),
                        new Item("Monitor", 5.0, "Tech"),
                        new Item("Smartphone", 0.5, "Tech")
                    }),
                    new Container("C104", new List<Item>
                    {
                        new Item("Server Rack", 45.0, "Tech"), // Heavy Item
                        new Item("Cables", 1.2, "Tech")
                    })
                },

                // ROW 1: Mixed Consumer Goods
                new List<Container>
                {
                    new Container("C002", new List<Item>
                    {
                        new Item("Apple", 0.2, "Food"),
                        new Item("Banana", 0.2, "Food"),
                        new Item("Milk", 1.0, "Food")
                    }),
                    new Container("C003", new List<Item>
                    {
                        new Item("Table", 15.0, "Furniture"),
                        new Item("Chair", 7.5, "Furniture")
                    })
                },

                // ROW 2: Fragile & Perishables (Includes an Empty Container)
                new List<Container>
                {
                    new Container("C205", new List<Item>
                    {
                        new Item("Vase", 3.0, "Decor"),
                        new Item("Mirror", 12.0, "Decor")
                    }),
                    new Container("C206", new List<Item>()) // EDGE CASE: Container with no items
                },

                // ROW 3: EDGE CASE - Empty Row
                new List<Container>() // A row that exists but has no containers
            };


            List<string> FindHeavyContainers(List<List<Container>> cargoBay, double weightThreshold)
            {
                var result = new List<string>();

                var heavyContainer = cargoBay.SelectMany(c => c).Where(c => c.Items.Sum(i => i.Weight) > weightThreshold)
                    .Select(c => c.ContainerID.OrderBy(c => c).ToList();
                if(cargoBay == null)
                {
                    return result;
                }
                foreach(var row in cargoBay)
                {
                    if (row == null) continue;
                    
                    foreach(var cont in row)
                    {
                        if (cont.Items == null) continue;

                        double weight = cont.Items.Sum(x => x.Weight);
                        if(weight > weightThreshold)
                        {
                            result.Add(cont.ContainerID);
                        }
                    }
                }
                return result;
            }

            Dictionary<string, int> GetItemCountsByCategory(Container c)
            {
                if (cargoBay == null) return new Dictionary<string, int>();

                var count = c.Items.GroupBy(x => x.Category).Select(x => new
                {
                    x.Key,
                    sum = x.Count()
                }).ToDictionary(x => x.Key, y => y.sum);

                return count;
            }

            List<Item> FlattenAndSortShipment(List<List<Container>> c)
            {
                if (c == null) return new List<Item>();

                
                var sorted = c.SelectMany(x => x).GroupBy(x => x).OrderBy(c => c.Category).ThenByDescending(w => w.Weight).ToList<Item>();

                return sorted;
            }

        }
    }
}


