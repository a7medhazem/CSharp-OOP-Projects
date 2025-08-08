using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class Librarian : User
    {
        public int EmployeeNumber;

        public Librarian(string name)
        {
            Name = name;
        }

        public void AddBook(Book NewBook, Library library)
        {
            library.AddBook(NewBook);
        }
        public void RemoveBook(Book NewBook, Library library)
        {
            library.RemoveBook(NewBook);
        }

    }
}
