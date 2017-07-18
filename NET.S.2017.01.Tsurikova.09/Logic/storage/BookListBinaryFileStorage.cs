using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.storage
{
    /// <summary>
    /// class for working with binary file storage
    /// </summary>
    public class BookListBinaryFileStorage : IBookListStorage
    {
        /// <summary>
        /// name of file to be worked with
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// initializes new instance of the class using the source data
        /// </summary>
        /// <param name="path">name of file to be worked with</param>
        public BookListBinaryFileStorage(string path)
        {
            FileName = path;
        }

        /// <summary>
        /// gets books from file
        /// </summary>
        /// <returns>list of books</returns>
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

        /// <summary>
        /// save books in file
        /// </summary>
        /// <param name="books">books to be saved</param>
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
