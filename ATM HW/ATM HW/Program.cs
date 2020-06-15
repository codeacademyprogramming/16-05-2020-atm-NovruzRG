using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_HW
{
    class Program
    {
        static void Main(string[] args)
        {
            User[] users = new User[5];
            users[0] = new User("ID1Name", "ID1Surname", new Card("4174 0000 0000 0001", "1111", "222", "01/21", 1500));
            users[1] = new User("ID2Name", "ID2Surname", new Card("4174 0000 0000 0002", "2222", "333", "02/22", 6000));
            users[2] = new User("ID3Name", "ID3Surname", new Card("4174 0000 0000 0003", "3333", "444", "03/23", 2700));
            users[3] = new User("ID4Name", "ID4Surname", new Card("4174 0000 0000 0004", "4444", "555", "04/24", 900));
            users[4] = new User("ID5Name", "ID5Surname", new Card("4174 0000 0000 0005", "5555", "666", "05/25", 400));
            CheckUser(users);
        }
        static void CheckUser(User[] users)
        {
            Console.WriteLine("Enter your PIN Code");
            string PinCode = Console.ReadLine();
            Boolean checkUser = false;
            for (int i = 0; i < users.Length; i++)
            {
                if (PinCode == users[i].CreditCard.PIN)
                {
                    checkUser = true;
                    UserMenu(users, i);
                }
            }
            if (!checkUser)
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine("Wrong PIN Code");
                Console.WriteLine("Enter your PIN Code");
                PinCode = Console.ReadLine();
                CheckUser(users);
            }
        }
        static void UserMenu(User[] users, int i)
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"Welcome {users[i].Name} {users[i].Surname}");
            Console.WriteLine("Choose one");
            Console.WriteLine("1. Balance --- Press 1");
            Console.WriteLine("2. Cash    --- Press 2");
            int.TryParse(Console.ReadLine(), out int userOption);
            switch (userOption)
            {
                case 1:
                    Balance(users, i);
                    break;
                case 2:
                    Cash(users, i);
                    break;
                default:
                    Console.WriteLine("Wrong option");
                    CheckUser(users);
                    break;
            }
        }
        static void Balance(User[] users, int i)
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"Your Balace --- {users[i].CreditCard.Balance}");
            Console.WriteLine($"For more option Enter PIN Code");
            CheckUser(users);
        }
        static void Cash(User[] users, int i)
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Choose one");
            Console.WriteLine("1. 10   --- Press 1");
            Console.WriteLine("2. 20   --- Press 2");
            Console.WriteLine("3. 50   --- Press 3");
            Console.WriteLine("4. 100  --- Press 4");
            Console.WriteLine("5. Type --- Press 5");
            int.TryParse(Console.ReadLine(), out int userCashOption);
            switch (userCashOption)
            {
                case 1:
                    CheckBalance(users, i, 10);
                    break;
                case 2:
                    CheckBalance(users, i, 20);
                    break;
                case 3:
                    CheckBalance(users, i, 50);
                    break;
                case 4:
                    CheckBalance(users, i, 100);
                    break;
                case 5:
                    Console.WriteLine("Type amount");
                    int.TryParse(Console.ReadLine(), out int userTypeOption);
                    CheckBalance(users, i, userTypeOption);
                    break;
                default:
                    Console.WriteLine("Wrong option");
                    CheckUser(users);
                    break;
            }
        }
        static void CheckBalance(User[] users, int i, int cashAmount)
        {
            if (users[i].CreditCard.Balance >= cashAmount && users[i].CreditCard.Balance > 0)
            {
                users[i].CreditCard.Balance -= cashAmount;
                Console.WriteLine("Done - Take the receipt");
                CheckUser(users);
            }
            else
            {
                Console.WriteLine("No enough money in your Balance.");
                CheckUser(users);
            }
        }
    }

    class Card
    {
        public string PAN { get; set; }
        public string PIN { get; set; }
        public string CVC { get; set; }
        public string ExpireDate { get; set; }
        public decimal Balance { get; set; }
        public Card(string pan, string pin, string cvc, string expireDate, decimal balance)
        {
            PAN = pan;
            PIN = pin;
            CVC = cvc;
            ExpireDate = expireDate;
            Balance = balance;
        }
    }
    class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Card CreditCard { get; set; }

        public User(string name, string surname, Card creditCard)
        {
            Name = name;
            Surname = surname;
            CreditCard = creditCard;
        }
    }
}
