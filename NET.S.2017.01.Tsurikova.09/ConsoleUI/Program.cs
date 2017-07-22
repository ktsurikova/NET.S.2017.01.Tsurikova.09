using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using ConsoleUI.BookComparer;
using Logic;
using Logic.logging;
using Logic.storage;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new NLogger();
            try
            {
                Book book1 = new Book(1, "White Fang", "Jack London", 2007);
                //Console.WriteLine(book1);
                //Console.WriteLine(book1.GetHashCode());
                Book book2 = new Book(4, "Fahrenheit 451", "Ray Bradbury", 2000);
                Book book3 = new Book(2, "The Last of the Mohicans", "James Fenimore Cooper", 2012);
                Book book4 = new Book(3, "The Old Man and the Sea", "Ernest Hemingway", 2005);
                Book book5 = new Book(5, "The Adventures of Tom Sawyer", "Mark Twain", 2017);
                //Console.WriteLine(book1.Equals(book3));
                //Console.WriteLine(book1.Equals(book2));

               // XmlSerializer ser = new XmlSerializer(typeof(List<Book>));
                //List<Book> books = new List<Book>() {book1, book2, book3, book4, book5};
                //FileStream writer = new FileStream(@"D:\training\NET.S.2017.01.Tsurikova.09\NET.S.2017.01.Tsurikova.09\ConsoleUI\data\data3.txt", FileMode.Create);
                //DataContractSerializer ser =
                //    new DataContractSerializer(typeof(List<Book>));
                //ser.WriteObject(writer, books);
                //writer.Close();

                //XmlSerializer x = new XmlSerializer(typeof(List<Book>));
                //TextWriter writer = new StreamWriter(@"D:\training\NET.S.2017.01.Tsurikova.09\NET.S.2017.01.Tsurikova.09\ConsoleUI\data\data3.txt");
                //x.Serialize(writer, books);

                //XDocument xmlDocument = new XDocument(
                //    new XDeclaration("1.0", "utf-8", "yes"),

                //    new XElement("Books",

                //        from book in books
                //        select new XElement("Book",
                //            new XElement("Id", book.Id),
                //            new XElement("Name", book.Name),
                //            new XElement("Author", book.Author),
                //            new XElement("YearOfPublication", book.YearOfPublication))

                //    ));
                //xmlDocument.Save(@"D:\training\NET.S.2017.01.Tsurikova.09\NET.S.2017.01.Tsurikova.09\ConsoleUI\data\data3.txt");

                //IEnumerable<Book> Boo = from BOOKS in
                //    XDocument.Load(@"D:\training\NET.S.2017.01.Tsurikova.09\NET.S.2017.01.Tsurikova.09\ConsoleUI\data\data3.txt")
                //        .Descendants("Book")
                //    select new Book(int.Parse(BOOKS.Element("Id").Value), BOOKS.Element("Name").Value,
                //    BOOKS.Element("Author").Value, int.Parse(BOOKS.Element("YearOfPublication").Value));

                //foreach (var VARIABLE in Boo)
                //{
                //    Console.WriteLine(VARIABLE);
                //}

                BookListService service = new BookListService();
                //service.Add(book2);
                //service.Add(book1);
                ////service.Add(book2);
                //service.Add(book3);
                //foreach (var VARIABLE in service)
                //{
                //    Console.WriteLine(VARIABLE);
                //}
                //Console.WriteLine();
                //Console.WriteLine(service.FindBookByTag(i=>i.YearOfPublication>2005));
                //service.Remove(book1);
                //Console.WriteLine();
                //foreach (var VARIABLE in service)
                //{
                //    Console.WriteLine(VARIABLE);
                //}k
                //service.SaveToStorage(
                //    new BookSerializationStorage(
                //        @"D:\training\NET.S.2017.01.Tsurikova.09\NET.S.2017.01.Tsurikova.09\ConsoleUI\data\data2.txt"));
                ////service.Remove(book2);
                //service.Remove(book3);
                service.GetFromStorage(new BookXmlStorage(@"D:\training\NET.S.2017.01.Tsurikova.09\NET.S.2017.01.Tsurikova.09\ConsoleUI\data\data3.txt"));
                Console.WriteLine();
                //service.T();
                service.SortBooksByTag(new BookNameComparer());
                Console.WriteLine();
                //service.T();
            }
            catch (ArgumentNullException e)
            {
                logger.Info(DateTime.Now, e.Message, e.StackTrace);
            }
            catch (ArgumentException e)
            {
                logger.Info(DateTime.Now, e.Message, e.StackTrace);
            }
            catch (BookStrorageException e)
            {
                logger.Info(DateTime.Now, e.Message, e.StackTrace);
            }
            catch (Exception e)
            {
                logger.Error(DateTime.Now, e.Message, e.StackTrace);
            }

            Console.ReadLine();
        }
    }
}
