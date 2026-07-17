using LibrarySystem.Entities.Enums;

namespace LibrarySystem.Entities
{
    internal class Book
    {
        public  int Id { get;  set; }
        public string Title{ get; set; }
        public int Year { get; set; }

        public Genre Genre { get; set; }
        public int Stock { get; set; }

        public Book(string title, int year, Genre genre, int stock)
        {
            Id = 0;
            Title = title;
            Year = year;
            Genre = genre;
            Stock = stock;
        
        }

        public Book(int id, string title, int year, Genre genre, int stock)
        {
            Id = id;
            Title = title;
            Year = year;
            Genre = genre;
            Stock = stock;
        }

        public override string ToString()
        {
            return $"{Id}, {Title}, {Year}, {Genre}, {Stock} copies";
        }
    }
}
