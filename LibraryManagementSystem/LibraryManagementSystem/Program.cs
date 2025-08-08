using System.Xml.Linq;

namespace LibraryManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\tWelcome to Library System");

            // object is created here to be able to display , remove or add
            Library library = new Library();
            const string LibrarianSystemPassword = "Admin2025###";

            Console.WriteLine("=========================================");
            Console.WriteLine("1. Login as Librarian");
            Console.WriteLine("2. Login as User");
            Console.WriteLine("3. Exit");
            Console.WriteLine("=========================================");
            Console.Write("Select an option: ");
            bool CheckUserType = int.TryParse(Console.ReadLine(), out int UserType);

            if (CheckUserType)
            {

                if (UserType == 1)
                {
                    Console.WriteLine("Welcome Librarian");
                    Console.WriteLine("=========================================");
                    Console.Write("Your name: ");
                    string LibrarianName = Console.ReadLine();
                    Console.WriteLine("=========================================");
                    Console.Write("Your password: ");
                    string LibrarianPassword = ReadPassword();
                    Console.WriteLine("");
                    Console.WriteLine("=========================================");
                    if (LibrarianSystemPassword == LibrarianPassword)
                    {
                        Librarian l1 = new Librarian(LibrarianName);

                        Console.WriteLine($"Welcome {l1.Name}");
                        while (true)
                        {
                            Console.WriteLine("=========================================");

                            Console.WriteLine("Please select an option:");
                            Console.WriteLine();
                            Console.WriteLine("   [A] - Add a new book");
                            Console.WriteLine("   [R] - Remove a book");
                            Console.WriteLine("   [D] - Display all books");
                            Console.WriteLine("   [Q] - Quit");
                            Console.WriteLine();
                            Console.Write("Your choice: ");

                            char UserChoice = Console.ReadLine().ToUpper().ToCharArray()[0];

                            Console.WriteLine("=========================================");

                            switch (UserChoice)
                            {
                                case 'A':
                                    {

                                        Book book = GetBookDetails("add");
                                        if (book != null)
                                            l1.AddBook(book, library);
                                        break;
                                    }
                                case 'R':
                                    {
                                        Book book = GetBookDetails("remove");
                                        if (book != null)
                                            l1.RemoveBook(book, library);
                                        break;
                                    }
                                case 'D':
                                    l1.DisplayBooks(library);
                                    break;                                    
                                case 'Q':
                                    Environment.Exit(0);
                                    break;            
                                default:
                                    Console.WriteLine("Invalid choice, please try again.");
                                    break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Incorrect password. Please try again.");
                    }
                }
                else if (UserType == 2)
                {

                    Console.WriteLine("Welcome Regular user, please enter your name");
                    Console.WriteLine("=========================================");
                    Console.Write("Your name: ");
                    string RegularUserName = Console.ReadLine();
                    Console.WriteLine("=========================================");

                    LibraryUser l1 = new LibraryUser(RegularUserName);

                    Console.WriteLine($"Welcome {l1.Name}");

                    while (true)
                    {
                        Console.WriteLine("=========================================");

                        Console.WriteLine("Please select an option:");
                        Console.WriteLine();
                        Console.WriteLine("   [B] - Borrow a book");
                        Console.WriteLine("   [D] - Display all books");
                        Console.WriteLine("   [Q] - Quit");
                        Console.WriteLine();
                        Console.Write("Your choice: ");

                        char UserChoice = Console.ReadLine().ToUpper().ToCharArray()[0];
                        Console.WriteLine("=========================================");

                        switch (UserChoice)
                        {
                            case 'B':
                                {
                                    Book book = GetBookDetails("borrow");
                                    if (book != null)
                                        l1.BorrowBook(book, library);
                                    break;
                                }
                            case 'D':
                                l1.DisplayBooks(library);
                                break;
                            case 'Q':
                                Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine("Invalid choice, please try again.");
                                break;
                        }
                    }

                }
                else if (UserType == 3)
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Invalid option. Try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }


        // Method to get book details from the user (for Add, Remove or Borrow actions
        static Book GetBookDetails(string action)
        {
            Console.WriteLine($"Enter book details to {action}:");

            Console.Write("Enter book name: ");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Book name cannot be empty.");
                return null;
            }

            Console.Write("Enter book Author: ");
            string author = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(author))
            {
                Console.WriteLine("Author name cannot be empty.");
                return null;
            }

            Console.Write("Enter book Year: ");
            bool isValidYear = int.TryParse(Console.ReadLine(), out int year);

            if (!isValidYear)
            {
                Console.WriteLine("Invalid year input. Please try again.");
                return null;
            }

            return new Book()
            {
                Title = name,
                Author = author,
                Year = year
            };
        }

        // Method to read password with asterisks '*'
        static string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                // If the key is not a control key (like Enter or Backspace)
                if (!char.IsControl(key.KeyChar))
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
                // If Backspace is pressed and there is at least one character
                else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    // Remove the last character from the password
                    password = password.Substring(0, password.Length - 1);

                    // Remove the last asterisk from the console
                    Console.Write("\b \b");
                }

            }
            while (key.Key != ConsoleKey.Enter); // Continue until Enter is pressed

            return password; // Return the actual password (without asterisks)
        }
    }
}

