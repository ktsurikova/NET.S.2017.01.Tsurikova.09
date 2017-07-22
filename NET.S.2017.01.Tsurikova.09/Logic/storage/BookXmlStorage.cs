using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Logic.storage
{
    /// <summary>
    /// class for working with xml file storage
    /// </summary>
    public class BookXmlStorage : IBookStorage
    {
        /// <summary>
        /// name of file to be worked with
        /// </summary>
        public string FileName { get; }

        /// <summary>
        /// initializes new instance of the class using the source data
        /// </summary>
        /// <param name="path">name of file to be worked with</param>
        public BookXmlStorage(string path)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentException($"{nameof(path)} must have valueS");
            FileName = path;
        }

        /// <summary>
        /// gets books from file
        /// </summary>
        /// <returns>list of books</returns>
        public IEnumerable<Book> GetBooks()
        {
            if (!File.Exists(FileName)) throw
                new BookStrorageException($"there is no file with such name {FileName}");

            return from Books in
                XDocument.Load(FileName)
                    .Descendants("Book")
                select new Book(int.Parse(Books.Element("Id").Value), Books.Element("Name").Value,
                    Books.Element("Author").Value, int.Parse(Books.Element("YearOfPublication").Value));

        }

        /// <summary>
        /// save books in file
        /// </summary>
        /// <param name="books">books to be saved</param>
        public void SaveBooks(IEnumerable<Book> books)
        {
            XDocument xmlDocument = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("Books",
                    from book in books
                    select new XElement("Book",
                        new XElement("Id", book.Id),
                        new XElement("Name", book.Name),
                        new XElement("Author", book.Author),
                        new XElement("YearOfPublication", book.YearOfPublication))

                ));
            xmlDocument.Save(FileName);
        }
    }
}
