using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleUI.BookComparer;
using Logic;
using Logic.storage;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
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

            BookListService service = new BookListService { book1, book2, book3, book4, book5 };
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
            //}
            service.SaveToStorage(new BookBinaryFileStorage(@"D:\training\NET.S.2017.01.Tsurikova.09\NET.S.2017.01.Tsurikova.09\ConsoleUI\data\data.txt"));
            //service.Remove(book2);
            //service.Remove(book3);
            service.GetFromStorage(new BookBinaryFileStorage(@"D:\training\NET.S.2017.01.Tsurikova.09\NET.S.2017.01.Tsurikova.09\ConsoleUI\data\data.txt"));
            Console.WriteLine();
            foreach (var VARIABLE in service)
            {
                Console.WriteLine(VARIABLE);
            }
            service.SortBooksByTag(new BookYearComparer());
            Console.WriteLine();
            foreach (var VARIABLE in service)
            {
                Console.WriteLine(VARIABLE);
            }


            Console.ReadLine();
        }
    }
}
