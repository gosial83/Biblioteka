using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ex3.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Email { get; private set; }
        private string _password;
        public bool IsAactive { get; set; }

        public List<Book> BorrowedBook = new List<Book>();

        public User(string name, string surname, int age, string password)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Email = GenerateEmail();
            this._password = password;
            IsAactive = true;
        }

        public void Add()
        {
            DatabaseDummy.UsersList.Add(this);
        }

        public static void PrintUsersList()
        {
            if (DatabaseDummy.IsAnyUserInUsersList() == true)
            {
                string id = "ID";
                string name = "NAME";
                string surname = "LAST NAME";
                string email = "EMAIL";
                string age = "Age";
                string isActive = "IS ACTIV";
                string books = "BOOKS";

                Console.WriteLine(" {0,-3} | {1,-12} | {2,-12} | {3,-20} | {4,-3} | {5,-8} | {6,-3}", id, name, surname, email, age,
                    isActive, books);

                int i = 1;
                foreach (var user in DatabaseDummy.UsersList)
                {
                    Console.WriteLine(" {0,-3} | {1,-12} | {2,-12} | {3,-20} | {4,-3} | {5,-8} | {6,-3}", i, user.Name, user.Surname,
                        user.Email, user.Age, user.IsAactive, user.BorrowedBook.Count);
                    i++;
                }
            }
        }

        public string GenerateEmail()
        {
            string firstTwoSign = Name.Substring(0, 2);
            string lastTwoSign = Surname.Substring(Surname.Length - 2, 2);
            string email = firstTwoSign + lastTwoSign + "@o2.pl";
            return email;
        }


        public void Remove()
        {
            this.IsAactive = false;
            Console.WriteLine($"User {this.Name} {this.Surname} ({this.Email}) removed.");
        }

        public static void PrintBoorowedBookOfUser(User choosenUser)
        {
            Console.WriteLine($"List of books boorowed by user: {choosenUser.Name} {choosenUser.Surname}");

            if (choosenUser.BorrowedBook.Count != 0)
            {
                foreach (var book in choosenUser.BorrowedBook)
                {
                    Console.WriteLine(book.Title);
                }
            }
        }
    }
}