using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex3.Models
{
    public class Book:IBorrowable
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public string PublishingHouse { get; set; }
        public bool IsAvilable { get; set; }

        public Book()
        {
            
        }

        public Book(string title, string author, int publicationYear, string publishingHouse)
        { 
            Title = title;
            Author = author;
            IsAvilable = true;
            PublicationYear = publicationYear;
            PublishingHouse = publishingHouse;
        }

        public void Add()
        {

            DatabaseDummy.BooksList.Add(this);
        }

        public void Borrow(User user)
        {
            this.IsAvilable = false;
            user.BorrowedBook.Add(this);

 
        }



        public static void PrintBooksList()
        {
            if (DatabaseDummy.IsAnyBookInBookList() == true)
            {
                string id = "ID";
                string title = "TITLE";
                string author = "AUTHOR";
                string publicationYear = "PUBLIC YEAR";
                string publishingHouse = "PUBLISHING HOUSE";
                string isAvilable = "IS AVILABLE";


                Console.WriteLine(" {0, -3} | {1,-12} | {2,-20} | {3,-12} |{4,-12} | {5,-3} ", id, title, author, publicationYear, publishingHouse, isAvilable);

                int i = 1;
                foreach (var book in DatabaseDummy.BooksList)
                {
                    Console.WriteLine(" {0, -3} | {1,-12} | {2,-20} | {3,-12} |{4,-12} | {5,-3} ", i, book.Title, book.Author, book.PublicationYear, book.PublishingHouse, book.IsAvilable);
                    i++;

                }
            }



        }



    }
}
