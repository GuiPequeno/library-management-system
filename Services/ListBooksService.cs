using LibrarySystem.Entities;
using LibrarySystem.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Services
{
    internal class ListBooksService
    {
        private static readonly string _filePath;
        List<Book> books = new List<Book>();


        static ListBooksService()
        {
            string Documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            _filePath = Path.Combine(Documents, "Library.csv");
        }

        static void Print<T>(string message, IEnumerable<T> collection)
        {
            Console.WriteLine();
            Console.WriteLine(message);
            foreach (T obj in collection)
            {
                Console.WriteLine(obj);
            }
            Console.WriteLine();
        }
        public void ShowBooks()
        {
            Console.WriteLine("----------------------------------------");
            using (StreamReader sr = File.OpenText(_filePath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();

                    if (line.StartsWith("sep=,"))
                    {

                    }
                    else if (line.StartsWith("ID"))
                    {
                        Console.WriteLine("ID,TITLE,YEAR,GENRE,STOCK");
                        Console.WriteLine();
                    }
                    else
                    {

                        string[] data = line.Split(',');
                        int id = int.Parse(data[0]);
                        string title = data[1];
                        int year = int.Parse(data[2]);
                        Genre genre = Enum.Parse<Genre>(data[3]);
                        int stock = int.Parse(data[4]);

                        Book book = new Book(id, title, year, genre, stock);
                        books.Add(book);

                    }
                }

                foreach (Book book in books)
                {
                    Console.WriteLine(book);
                }
                books.Clear();
            }
            Console.WriteLine("----------------------------------------");
        }

        public void ShowBooksByCategory()
        {
            using (StreamReader sr = File.OpenText(_filePath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();

                    if (line.StartsWith("sep=,") || line.StartsWith("ID"))
                    {

                    }
                   
                    else
                    {
                        string[] data = line.Split(',');
                        int id = int.Parse(data[0]);
                        string title = data[1];
                        int year = int.Parse(data[2]);
                        Genre genre = Enum.Parse<Genre>(data[3]);
                        int stock = int.Parse(data[4]);

                        Book book = new Book(id, title, year, genre, stock);
                        books.Add(book);

                    }
                }
                Console.WriteLine();
                Console.WriteLine("----------------------------------------");

                var adventure = books.Where(b => b.Genre == Genre.Adventure);
                Print("ADVENTURE", adventure);

                var fantasy = books.Where(b => b.Genre == Genre.Fantasy);
                Print("FANTASY", fantasy);

                var romance = books.Where(b => b.Genre == Genre.Romance);
                Print("ROMANCE", romance);

                var horror = books.Where(b => b.Genre == Genre.Horror);
                Print("HORROR", horror);

                var biography = books.Where(b => b.Genre == Genre.Biography);
                Print("BIOGRAPHY", biography);

                Console.WriteLine("----------------------------------------");
                books.Clear();


            }
        }
    }
}
