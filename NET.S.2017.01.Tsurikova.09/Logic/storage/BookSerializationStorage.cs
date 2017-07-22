using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Logic.storage
{
    /// <summary>
    /// class for working with binary file storage
    /// </summary>
    public class BookSerializationStorage : IBookStorage
    {
        private BinaryFormatter formatter;
        /// <summary>
        /// name of file to be worked with
        /// </summary>
        public string FileName { get; }

        /// <summary>
        /// initializes new instance of the class using the source data
        /// </summary>
        /// <param name="path">name of file to be worked with</param>
        public BookSerializationStorage(string path)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentException($"{nameof(path)} must have valueS");
            FileName = path;
            formatter = new BinaryFormatter();
        }

        /// <summary>
        /// gets books from file
        /// </summary>
        /// <returns>list of books</returns>
        public IEnumerable<Book> GetBooks()
        {
            if (!File.Exists(FileName)) throw
                new BookStrorageException($"there is no file with such name {FileName}");

            List<Book> deserilizeBooks;

            using (FileStream fs = new FileStream(FileName, FileMode.Open))
            {
                deserilizeBooks = (List<Book>)formatter.Deserialize(fs);
            }

            return deserilizeBooks;
        }

        /// <summary>
        /// save books in file
        /// </summary>
        /// <param name="books">books to be saved</param>
        public void SaveBooks(IEnumerable<Book> books)
        {
            using (FileStream fs = new FileStream(FileName, FileMode.Create))
            {
                formatter.Serialize(fs, books);
            }
        }
    }
}
