using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class Books
    {
        public string BookName { get; set; }
        public string AuthorName { get; set; }

        public Books(string bookName, string authorName)
        {
            BookName = bookName;
            AuthorName = authorName;
        }

        public void Display()
        {
            Console.WriteLine($"Book Name: {BookName}, Author: {AuthorName}");
        }
    }

    class BookShelf
    {
        private Books[] books;

        public BookShelf()
        {
            books = new Books[5]; 
            books[0] = new Books("The Immortals of Meluha", "Amish Tripathi");
            books[1] = new Books("2 States", "Chetan Bhagat");
            books[2] = new Books("Rich Dad Poor Dad", "Robert t Kiyosaki");
            books[3] = new Books("The Power of Positive Thinking", "Norman Vincent Peale");
            books[4] = new Books("Atomic Habits", "James Clear");
        }

        public Books this[int index]
        {
            get
            {
                if (index >= 0 && index < 5)
                    return books[index];
                else
                    throw new IndexOutOfRangeException("Index out of range.");
            }
            set
            {
                if (index >= 0 && index < 5)
                    books[index] = value;
                else
                    throw new IndexOutOfRangeException("Index out of range.");
            }
        }

        public void DisplayAllBooks()
        {
            foreach (var book in books)
            {
                book.Display();
            }
        }
    }

    class Book
    {
        static void Main(string[] args)
        {
            BookShelf shelf = new BookShelf();
            Console.WriteLine("Books in the shelf:");
            shelf.DisplayAllBooks();
            Console.Read();
        }
    }
}
