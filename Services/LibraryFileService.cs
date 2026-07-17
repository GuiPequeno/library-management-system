using LibrarySystem.Entities;
using System.Net;

namespace LibrarySystem.Services
{
    internal class LibraryFileService
    {
        private readonly string _filePath;

        public LibraryFileService()
        {
            string Documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            _filePath = Path.Combine(Documents, "Library.csv");
        }

        public int GetId()
        {
            if (!File.Exists(_filePath))
                return 1;

            string ultimaLinha = File.ReadLines(_filePath).LastOrDefault(l => !string.IsNullOrWhiteSpace(l));

            if (string.IsNullOrEmpty(ultimaLinha) || ultimaLinha.StartsWith("ID", StringComparison.OrdinalIgnoreCase))
                return 1;

            string[] lines = File.ReadAllLines(_filePath);
            for (int i = 1; i < lines.Length; i++)
            {
                if (CheckId(i) == false)
                {
                    return i;
                }
            }

            string[] dados = ultimaLinha.Split(',');

            return int.Parse(dados[0]) + 1;
        }

        public bool CheckId(int IdToCheck)
        {
            string[] lines = File.ReadAllLines(_filePath);
            bool IdExists = false;
            for (int i = 2; i < lines.Length; i++)
            {
                string[] data = lines[i].Split(',');
                int BookId = int.Parse(data[0]);

                if (IdToCheck == BookId)
                {
                    IdExists = true;
                }
            }
            return IdExists;


        }

        public void AddBook(Book book)
        {
            book.Id = GetId();
            FileInfo fileInfo = new FileInfo(_filePath);
            bool needsHeader = !File.Exists(_filePath) || fileInfo.Length == 0;


            if (needsHeader)
            {
                List<string> lines = new List<string>();
                lines.Add("sep=,");
                lines.Add("ID,TITLE,YEAR,GENRE,STOCK");
                lines.Add($"{book.Id},{book.Title},{book.Year},{book.Genre},{book.Stock}");
                File.WriteAllLines(_filePath, lines);

            }
            else
            {
                List<string> header = new List<string>();
                header.Add("sep=,");
                header.Add("ID,TITLE,YEAR,GENRE,STOCK");

                List<string> books = File.ReadLines(_filePath).Skip(2).ToList();
                books.Add($"{book.Id},{book.Title},{book.Year},{book.Genre},{book.Stock}");
                books = books.OrderBy(item => item.Split(',')[1]).ToList();

                File.WriteAllLines(_filePath, header.Concat(books));


            }




        }

        public void DeleteBook(int bookId)
        {
            string[] lines = File.ReadAllLines(_filePath);
            List<string> newLines = new List<string>() { lines[0], lines[1] };

            for (int i = 2; i < lines.Length; i++)
            {
                string[] data = lines[i].Split(",");

                int idToRemove = int.Parse(data[0]);

                if (!(idToRemove == bookId))
                {
                    newLines.Add(lines[i]);

                }

                File.WriteAllLines(_filePath, newLines);

            }
        }

        public void IncreaseStock(int bookId, int CopiesToAdd)
        {
            string[] lines = File.ReadAllLines(_filePath);
            List<string> newLines = new List<string>() { lines[0], lines[1] };

            for (int i = 2; i < lines.Length; i++)
            {
                string[] data = lines[i].Split(',');
                int IdToAdd = int.Parse(data[0]);

                if (IdToAdd == bookId)
                {
                    int Copies = int.Parse(data[4]);
                    CopiesToAdd += Copies;
                    data[4] = CopiesToAdd.ToString();

                    lines[i] = string.Join(",", data);

                }
                newLines.Add(lines[i]);

            }
            File.WriteAllLines(_filePath, newLines);
        }

        public void DecreaseStock(int bookId, int CopiesToRemove)
        {
            string[] lines = File.ReadAllLines(_filePath);
            List<string> newLines = new List<string>() { lines[0], lines[1] };

            for (int i = 2; i < lines.Length; i++)
            {
                string[] data = lines[i].Split(',');
                int IdToAdd = int.Parse(data[0]);

                if (IdToAdd == bookId)
                {
                    int Copies = int.Parse(data[4]);
                    if (Copies < CopiesToRemove)
                    {
                        Copies = 0;
                    }
                    else
                    {
                        Copies -= CopiesToRemove;
                    }
                    data[4] = Copies.ToString();

                    lines[i] = string.Join(",", data);

                }
                newLines.Add(lines[i]);

            }
            File.WriteAllLines(_filePath, newLines);

        }
    }
}
