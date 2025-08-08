using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class Library
    {
        private Book[] Books = new Book[100];
        private int CurrentBookCount = 0;

        private Book[] BorrowedBooks = new Book[50];
        private int CurrentBorrowedBookCount = 0;

        public void DisplayBooks()
        {
            if (CurrentBookCount == 0)
            {
                Console.WriteLine("There aren't any books available to Display.");
                return;
            }
            Console.WriteLine("Available books to Display.");

            for (int i = 0; i < CurrentBookCount; i++)
            {
                Console.WriteLine($"[Book{i + 1} ] => Name : {Books[i].Title}, Author :  {Books[i].Author}, Year : {Books[i].Year}");
                Console.WriteLine("-----------------------------------------");
            }

        }
        public void AddBook(Book NewBook)
        {
            if (CurrentBookCount < Books.Length)
            {
                Books[CurrentBookCount++] = NewBook;
                Console.WriteLine("Book added sucessfuly.");

            }
            else
            {
                Console.WriteLine("Library is full, can't add new book...");
            }

        }
        public void RemoveBook(Book bookToRemove)
        {
            if (CurrentBookCount == 0)
            {
                Console.WriteLine("There aren't any books available to remove.");
                return;
            }

            int index = -1;
            for (int i = 0; i < CurrentBookCount; i++)
            {
                if (Books[i] != null && Books[i].Title == bookToRemove.Title &&
                                        Books[i].Author == bookToRemove.Author &&
                                        Books[i].Year == bookToRemove.Year)
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            // Shift elements to the left to fill the gap
            for (int i = index; i < CurrentBookCount - 1; i++)
            {
                Books[i] = Books[i + 1];
            }

            Books[--CurrentBookCount] = null;
            Console.WriteLine("Book removed successfully.");
        }

        public void BorrowBook(Book book)
        {
            int index = -1;

            if (CurrentBorrowedBookCount < BorrowedBooks.Length)
            {
                for (int i = 0; i < CurrentBookCount; i++)
                {
                    if (Books[i].Title == book.Title &&
                        Books[i].Author == book.Author &&
                        Books[i].Year == book.Year)
                    {
                        index = i;
                        break;
                    }
                }
                if (index == -1)
                {
                    Console.WriteLine("this book isn't found in the library");
                }
                else
                {
                    BorrowedBooks[CurrentBorrowedBookCount++] = Books[index];

                    for (int i = index; i < CurrentBookCount - 1; i++)
                    {
                        Books[i] = Books[i + 1];
                    }

                    Books[--CurrentBookCount] = null;

                    Console.WriteLine("Book borrowed successfully.");
                }

            }
            else
            {
                Console.WriteLine("Sorry, can't borrow more...");
            }
        }
    }
}
