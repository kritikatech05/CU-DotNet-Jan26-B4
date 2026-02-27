namespace SocialNetworking
{
    class Person
    {
        public string Name { get; set; }
        public List<Person> Friends = new List<Person>();
        public Person(string name)
        {
            Name = name;
        }
        //public void AddFriend(Person friend)
        //{
        //    if (!Friends.Contains(friend))
        //    {
        //        Friends.Add(friend);
        //        friend.Friends.Add(this);


        //    }
        //}
    }
    class SocialNetwork
    {
        private List<Person> _members = new List<Person>();
        public void AddMember(Person member)
        {
            _members.Add(member);
        }

        public void AddFriend(Person friend1, Person friend2)
        {
            if(!(_members.Contains(friend1) && _members.Contains(friend2)))
            {
                Console.WriteLine($"one of friends {friend1.Name} {friend2.Name} are not on this social platform");
            }
            else if (friend1.Name == friend2.Name)
            {
                Console.WriteLine("you cannot be friends with yourself");
            }
            else
            {
                if (friend2.Friends.Contains(friend1))
                {
                    Console.WriteLine("already friends!!");
                }
                else
                {
                    friend1.Friends.Add(friend2);
                    friend2.Friends.Add(friend1);
                }
                
            }
                       
        }

        public void ShowNetwork()
        {
            foreach (var member in _members)
            {
                Console.Write(member.Name + " -> ");
                List<string> friends = new List<string>();
                foreach(var friend in member.Friends)
                {
                    friends.Add(friend.Name);

                }
                Console.WriteLine($"{string.Join(",", friends)}");
            }
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            SocialNetwork nw = new SocialNetwork();
            Person kritika = new Person("Kritika");
            Person komal = new Person("Komal");
            Person ekta = new Person("Ekta");
            Person kushagar = new Person("kushagar");
            Person tushar = new Person("tushar");
            Person shruti = new Person("Shruti");

            

            nw.AddMember(kritika);
            nw.AddMember(komal);
            nw.AddMember(ekta);
            nw.AddMember(kushagar);
            nw.AddMember(tushar);

            nw.AddFriend(kritika, komal);
            nw.AddFriend(kritika, komal);
            nw.AddFriend(kritika, shruti);
            nw.AddFriend(kritika, kushagar);
            nw.AddFriend(ekta, komal);
            nw.AddFriend(tushar, kushagar);
            nw.AddFriend(tushar, kritika);
            nw.AddFriend(ekta, kushagar);
            nw.AddFriend(kritika, kritika);
            
            //kritika.AddFriend(ekta);
            //kritika.AddFriend(komal);
            //kushagar.AddFriend(tushar);
            //ekta.AddFriend(tushar);

            nw.ShowNetwork();


        }
    }
}
