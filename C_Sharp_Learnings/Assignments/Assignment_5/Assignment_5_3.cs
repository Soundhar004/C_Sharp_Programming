using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Learnings.Assignments
{
    public class Books
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
            Console.WriteLine("Book: " + BookName + ", Author: " + AuthorName);
        }
    }
    public class BookShelf
    {
        private Books[] bookArray = new Books[5];
        public Books this[int index]
        {
            get
            {
                if (index >= 0 && index < bookArray.Length)
                    return bookArray[index];
                else
                    throw new IndexOutOfRangeException("Index out of bounds");
            }
            set
            {
                if (index >= 0 && index < bookArray.Length)
                    bookArray[index] = value;
                else
                    throw new IndexOutOfRangeException("Index out of bounds");
            }
        }
        public void DisplayBooks()
        {
            foreach (Books book in bookArray)
            {
                if (book != null)
                    book.Display();
            }
        }
    }
    class Assignment_5_3
    {
        static void Main()
        {
            BookShelf shelf = new BookShelf();
            shelf[0] = new Books("1984", "George Orwell");
            shelf[1] = new Books("The Hobbit", "J.R.R. Tolkien");
            shelf[2] = new Books("To Kill a Mockingbird", "Harper Lee");
            shelf[3] = new Books("Pride and Prejudice", "Jane Austen");
            shelf[4] = new Books("The Catcher in the Rye", "J.D. Salinger");
            shelf.DisplayBooks();
            Console.Read();
        }
    }
}
