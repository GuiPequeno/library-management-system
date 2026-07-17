using LibrarySystem.Services;
using LibrarySystem.Entities.Enums;
using LibrarySystem.Entities;

namespace LibrarySystem.Views
{
    internal class Menu
    {
        public LibraryFileService lf = new LibraryFileService();
        public ListBooksService lb = new ListBooksService();
        public void StartMenu()
        {
            Console.WriteLine();
            Console.WriteLine("=================================");
            Console.WriteLine("            MAIN MENU");
            Console.WriteLine("=================================");
            Console.WriteLine();
            Console.WriteLine("[1] Add Book");
            Console.WriteLine("[2] Delete Book");
            Console.WriteLine("[3] Increase Stock");
            Console.WriteLine("[4] Decrease Stock");
            Console.WriteLine("[5] Show Books by Category");
            Console.WriteLine("[6] Show All Books");
            Console.WriteLine("[7] EXIT");
            Console.WriteLine();
            Console.Write("Option: ");

            try
            {
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        MenuAddBook();
                        StartMenu();
                        break;
                    case 2:
                        MenuDeleteBook();
                        StartMenu();
                        break;
                    case 3:
                        MenuIncreaseStock();
                        StartMenu();
                        break;
                    case 4:
                        MenuDecreaseStock();
                        StartMenu();
                        break;
                    case 5:
                        lb.ShowBooksByCategory();
                        StartMenu();
                        break;
                    case 6:
                        lb.ShowBooks();
                        StartMenu();
                        break;
                    case 7:
                        break;
                    default:
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opção inválida!");
                        Console.ResetColor();
                        StartMenu();
                        break;
                }

            }
            catch (FormatException e)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Opção inválida!");
                Console.WriteLine(e.Message);
                Console.ResetColor();
                StartMenu();
            }
        }
        public void MenuAddBook()
        {
            Console.WriteLine();
            Console.Write("TITLE: ");
            string title = Console.ReadLine();
            Console.Write("YEAR: ");
            int year = int.Parse(Console.ReadLine());
            Console.Write("GENRE ([1]- Adventure [2]-Fantasy [3]- Romance [4]- Horror [5]- Biography) : ");
            int genreInput = int.Parse(Console.ReadLine());
            if (!(Enum.IsDefined(typeof(Genre), genreInput)))
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Opção inválida!");
                Console.ResetColor();
                StartMenu();
            }
            Genre genre = (Genre)genreInput;
            Console.Write("COPIES: ");
            int copies = int.Parse(Console.ReadLine());

            Book book = new Book(title, year, genre, copies);
            lf.AddBook(book);

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"'{book.Title}' was succesfully added");
            Console.ResetColor();
        }
        public void MenuDeleteBook()
        {
            Console.WriteLine();
            Console.Write("Insert the Id of the book: ");
            int bookId = int.Parse(Console.ReadLine());
            bool IdExists = lf.CheckId(bookId);
            if (IdExists)
            {
                lf.DeleteBook(bookId);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The book has been deleted");
                Console.ResetColor();

            }
            else
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Id not found!");
                Console.ResetColor();
            }

        }
        public void MenuIncreaseStock()
        {
            Console.Write("Insert id of the book: ");
            int bookId = int.Parse(Console.ReadLine());
            bool IdExists = lf.CheckId(bookId);
            if (IdExists)
            {
                Console.Write("How many copies?: ");
                int copies = int.Parse(Console.ReadLine());
                lf.IncreaseStock(bookId, copies);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Id not found!");
                Console.ResetColor();
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"The copies were succesfully added");
            Console.ResetColor();


        }
        public void MenuDecreaseStock()
        {
            Console.Write("Insert id of the book: ");
            int bookId = int.Parse(Console.ReadLine());
            bool IdExists = lf.CheckId(bookId);
            if (IdExists)
            {
                Console.Write("How many copies?: ");
                int copies = int.Parse(Console.ReadLine());
                lf.DecreaseStock(bookId, copies);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Id not found!");
                Console.ResetColor();
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"The copies were succesfully deleted");
            Console.ResetColor();
        }
    }
}