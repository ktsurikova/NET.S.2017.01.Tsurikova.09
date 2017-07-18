using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.storage
{
    public class BookListBinaryFileStorage : IBookListStorage
    {
        public string FileName { get; set; }

        public BookListBinaryFileStorage(string path)
        {
            FileName = path;
        }

        public List<Book> GetBooks()
        {
            List<Book> books = new List<Book>();

            if (!File.Exists(FileName)) return books;

            using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    int id = reader.ReadInt32();
                    string name = reader.ReadString();
                    string author = reader.ReadString();
                    int yaer = reader.ReadInt32();

                    books.Add(new Book(id, name, author, yaer));
                }
            }

            return books;
        }

        public void SaveBooks(List<Book> books)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.Create)))
            {
                foreach (Book b in books)
                {
                    writer.Write(b.Id);
                    writer.Write(b.Name);
                    writer.Write(b.Author);
                    writer.Write(b.YearOfPublication);
                }
            }
        }
    }
}
