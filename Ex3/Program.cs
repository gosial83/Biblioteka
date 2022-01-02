using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace Ex3.Models
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> MenuOptions = new List<string>();
            MenuOptions.Add(" 1. Add user.");
            MenuOptions.Add(" 2. Print users.");
            MenuOptions.Add(" 3. Delete user.");
            MenuOptions.Add(" 4. Add book.");
            MenuOptions.Add(" 5. Print books.");
            MenuOptions.Add(" 6. Borrow a book.");
            MenuOptions.Add(" 7. Boorowed books of user.");

            bool isEnd = false;
            int choosenOption;

            do
            {
                Console.Clear();
                Console.WriteLine("Welcome in LIBRARY: ");
                Console.WriteLine("____________________________________");
                foreach (var option in MenuOptions)
                {
                    Console.WriteLine(option.ToString());
                }
                Console.WriteLine("____________________________________");
                Console.WriteLine();

                Console.Write("Type menu option: ");
                choosenOption = GetData.GetNumberValuBeetwen(1, MenuOptions.Count);
                
                switch (choosenOption)
                {
                    case 1:
                    {
                        Menu.PrintHeading("1. Add user:");

                        Console.Write("Type name: ");
                        string name = GetData.GetText();

                        Console.Write("Type surname: ");
                        string surname = GetData.GetText();

                        Console.Write("Type age: ");
                        int age = GetData.GetAge();

                        Console.Write("Type password: ");
                        string password = Console.ReadLine();

                        User user = new User(name, surname, age, password);

                        user.Add();
                        Console.WriteLine($"\nUser {user.Name.ToUpper()} {user.Surname.ToUpper()} was added!");

                        Menu.BackToMainMenu();
                        break;
                    }
                    case 2:
                    {
                        Menu.PrintHeading("2. Print users:");
                        User.PrintUsersList();
                        Menu.BackToMainMenu();
                        break;
                    }
                    case 3:
                    {
                        Menu.PrintHeading("3. Remove user:");

                        Console.Write("Which user to remove? Type email of this user: ");
                        string emailOfUserToDelete = Console.ReadLine();
                        bool isFound = false;

                        for (int i = 0; i < DatabaseDummy.UsersList.Count; i++)
                        {
                            if (DatabaseDummy.UsersList[i].Email == emailOfUserToDelete)
                            {
                                DatabaseDummy.UsersList[i].Remove();
                                isFound = true;
                            }
                        }

                        if(isFound==false) 
                            Console.WriteLine($"User with email: {emailOfUserToDelete} doesn't exist.");

                        Menu.BackToMainMenu();
                        break;
                    }
                    case 4:
                    {
                        Menu.PrintHeading("4. Add book:");
                        
                        Console.Write($"Type title of new book: ");
                        string title = GetData.GetText();

                        Console.Write($"Type author: ");
                        string author = GetData.GetText();

                        Console.Write($"Type publicationy year: ");
                        int publicationYear = GetData.GetNumberValuBeetwen(1900, DateTime.Today.Year);

                        Console.Write($"Type publishing house: ");
                        string publishingHouse = GetData.GetText();

                        Book book = new Book(title, author, publicationYear, publishingHouse);

                        book.Add();
                        Console.Write($"\nBook {book.Title.ToUpper()} was added!");
                        Menu.BackToMainMenu();
                        break;
                    }
                    case 5:
                    {
                        Menu.PrintHeading("5. Print books list:");
                        Book.PrintBooksList();
                        Menu.BackToMainMenu();
                        break;
                    }
                    case 6:
                    {
                        Menu.PrintHeading("6. Borrow a book:");

                        int choosenBookId = 0;
                        if (DatabaseDummy.IsAnyBookInBookList()==true)
                        {
                            if (DatabaseDummy.IsAnyUserInUsersList()==true)
                            {
                                Console.WriteLine("Choose book from list:");
                                Book.PrintBooksList();
                                Console.WriteLine();
                                bool ifBorrowSuccers = false;

                                if (DatabaseDummy.IsAnyAvilableBook())
                                {
                                        Book choosenBook = new Book();
                                        do
                                        {
                                            Console.Write("Type ID of book: ");
                                            choosenBookId = GetData.GetNumberValuBeetwen(1, DatabaseDummy.BooksList.Count);
                                            choosenBook = DatabaseDummy.BooksList[choosenBookId - 1];

                                            if (choosenBook.IsAvilable == true)
                                            {
                                                Console.WriteLine();
                                                Console.WriteLine("Choose user from list:");
                                                User.PrintUsersList();
                                                while (DatabaseDummy.IsAnyActiveUser())
                                                {
                                                    Console.Write("\nType ID of user: ");
                                                    int choosenUserId = GetData.GetNumberValuBeetwen(1, DatabaseDummy.UsersList.Count);
                                                    User choosenUser = DatabaseDummy.UsersList[choosenUserId - 1];

                                                    if (choosenUser.IsAactive == true)
                                                    {
                                                        choosenBook.Borrow(choosenUser);
                                                        Console.Write($"\nBook {choosenBook.Title.ToUpper()} was borrowed by {choosenUser.Name.ToUpper()} {choosenUser.Surname.ToUpper()}! ");
                                                        ifBorrowSuccers = true;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine($"User {choosenUser.Name.ToUpper()} {choosenUser.Surname.ToUpper()} is not activ");
                                                    }
                                                }

                                                if (DatabaseDummy.IsAnyActiveUser() == false)
                                                {
                                                    Console.WriteLine("There isn't any active USERS");
                                                    Menu.BackToMainMenu();
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine($"Book {choosenBook.Title.ToUpper()} is not avilable");
                                            }
                                            if(ifBorrowSuccers == true)
                                                break;
                                        } while (!choosenBook.IsAvilable);
                                }

                                if (DatabaseDummy.IsAnyAvilableBook() == false)
                                {
                                    Console.WriteLine("There isn't any avilable BOOKS");
                                    Menu.BackToMainMenu();
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("You don't have any USERS in database!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("You don't have any BOOKS in database!");
                        }
                        
                        Menu.BackToMainMenu();
                        break;
                    }
                    case 7:
                    {
                        Menu.PrintHeading("7. Boorowed books of user:");
                        if (DatabaseDummy.IsAnyUserInUsersList() == true)
                        {
                            Console.WriteLine("Chooice user form list:");
                            User.PrintUsersList();
                            Console.Write("Type user ID: ");
                            int choosenUserId = GetData.GetNumberValuBeetwen(1, DatabaseDummy.UsersList.Count);
                                
                            User choosenUser = DatabaseDummy.UsersList[choosenUserId - 1];

                            if(choosenUser.BorrowedBook.Count!=0) 
                                User.PrintBoorowedBookOfUser(choosenUser);
                            else
                                Console.WriteLine($"User {choosenUser.Name.ToUpper()} {choosenUser.Surname.ToUpper()} didn't borrow any book.");
                        }

                        Menu.BackToMainMenu();
                        break;
                    }
                }
            } while (!isEnd);
        }
    }
}
