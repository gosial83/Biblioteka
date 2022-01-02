using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex3.Models
{
    static class DatabaseDummy
    {
        public static List<Book> BooksList = new List<Book>();
        public static List<User> UsersList = new List<User>();

        public static bool IsAnyUserInUsersList()
        {
            bool anyUser;
            if (UsersList.Count != 0)
            {
                anyUser = true;
            }
            else
            {
                anyUser = false;
                Console.WriteLine("You don't have any USERS in database!");
            }
            return anyUser;
        }


        public static bool IsAnyBookInBookList()
        {
            bool anyBook;
            if (BooksList.Count != 0)
            {
                anyBook = true;
            }
            else
            {
                anyBook = false;
                Console.WriteLine("You don't have any BOOKS in database!");
            }
            return anyBook;
        }


        public static bool IsAnyActiveUser()
        {
            bool anyActiveUser = false;
            foreach (var user in DatabaseDummy.UsersList)
            {
                if (user.IsAactive == true)
                    anyActiveUser = true;
            }
            return anyActiveUser;
        }


        public static bool IsAnyAvilableBook()
        {
            bool anyAvilableBok = false;
            foreach (var book in DatabaseDummy.BooksList)
            {
                if (book.IsAvilable == true)
                    anyAvilableBok = true;
            }
            return anyAvilableBok;
        }
    }
}
