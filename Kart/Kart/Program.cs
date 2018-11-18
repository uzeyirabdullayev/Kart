using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kart
{
    class Program
    {
        static void Main(string[] args)
        {
            Kart kart = new Kart(1, "Visa", 12345, 1234);
            Kart kart2 = new Kart(2, "MasterCart", 45678, 5678);
            Users user1 = new Users(3, "Ruslan", "Haqverdi", kart);
            Users user2 = new Users(4, "Shemistan", "Veliyev", kart2);
            List<Users> userlist = new List<Users>();
            userlist.Add(user1);
            userlist.Add(user2);
            List<Kart> kartlist = new List<Kart>();
            kartlist.Add(kart);
            kartlist.Add(kart2);

            Console.WriteLine("Kartin Pin kodunu daxil edin...");
            var pin = int.Parse(Console.ReadLine());
            var tapilmishkart = kartlist.AsParallel().FirstOrDefault(f => f.Pin == pin);
            if (tapilmishkart != null)
            {
                Console.WriteLine(tapilmishkart.Name);
            }

        }
    }

    class Kart
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Pin { get; set; }
        public int Cvc { get; set; }

        public Kart(int _id, string _name, int _pin, int _cvc)
        {
            ID = _id;
            Name = _name;
            Pin = _pin;
            Cvc = _cvc;
        }

    }

    class Users
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Kart kart { get; set; }
        public Users(int _id, string _name, string _surname, Kart karts)
        {
            ID = _id;
            Name = _name;
            Surname = _surname;
            kart = karts;
        }
    }
}
