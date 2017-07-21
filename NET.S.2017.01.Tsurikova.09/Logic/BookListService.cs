using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.logging;
using Logic.storage;

namespace Logic
{
    /// <summary>
    /// class providing functions for working with books
    /// </summary>
    public class BookListService
    {
        private List<Book> books;
        private ILogger logger;

        /// <summary>
        /// initializes new instance of the class
        /// </summary>
        public BookListService() : this(new NLogger())
        {
        }

        /// <summary>
        /// initializes new instance of the class
        /// </summary>
        /// <param name="otherLogger">instance of logger</param>
        public BookListService(ILogger otherLogger)
        {
            logger = otherLogger;
            books = new List<Book>();
            logger.Debug(DateTime.Now, "Ctor", "Service created");
        }

        /// <summary>
        /// initializes new instance of the class with source data
        /// </summary>
        /// <param name="otherBooks">books to be added for working with</param>
        /// <param name="otherLogger">intance of logger</param>
        /// <exception cref="ArgumentNullException">throws when books is null</exception>
        public BookListService(IEnumerable<Book> otherBooks, ILogger otherLogger = null)
        {
            if (ReferenceEquals(otherBooks, null)) throw new ArgumentNullException($"{nameof(otherBooks)} is null");
            logger = ReferenceEquals(logger, null) ? new NLogger() : otherLogger;
            books = new List<Book>();
            foreach (var book in otherBooks)
            {
                Add(book);
            }
            logger.Debug(DateTime.Now, "Ctor", "Service created");
        }

        /// <summary>
        /// adds book in list
        /// </summary>
        /// <param name="book">book to be added</param>
        /// <exception cref="ArgumentNullException">throws when book is null</exception>
        /// <exception cref="BookStrorageException">throws when strorage already contains the book</exception>
        public void Add(Book book)
        {
            if (ReferenceEquals(book, null)) throw new ArgumentNullException($"{nameof(book)} is null");
            if (!books.Contains(book))
                books.Add(book);
            else throw new BookStrorageException("strorage already contains this book");
            logger.Debug(DateTime.Now, "Add", $"book {book.Id} successfully added");
        }

        /// <summary>
        /// removes book in list
        /// </summary>
        /// <param name="book">book to be removed</param>
        /// <exception cref="ArgumentNullException">throws when book is null</exception>
        /// <exception cref="BookStrorageException">throws when sstorage doesn't contain the book</exception>
        public void Remove(Book book)
        {
            if (ReferenceEquals(book, null)) throw new ArgumentNullException($"{nameof(book)} is null");
            if (!books.Contains(book))
                throw new BookStrorageException("storage doesn't contain such book");
            books.Remove(book);
            logger.Debug(DateTime.Now, "Remove", $"book {book.Id} successfully removed");
        }

        /// <summary>
        /// Searches for a book that matches the conditions specified predicate
        /// </summary>
        /// <param name="tag">delegate defining the conditions for the search for an element</param>
        /// <returns>the first element satisfying the conditions specified predicate</returns>
        /// <exception cref="ArgumentNullException">throws when tag is null</exception>
        public Book FindBookByTag(Predicate<Book> tag)
        {
            if (ReferenceEquals(tag, null)) throw new ArgumentNullException($"{nameof(tag)} is null");
            return books.Find(tag);
        }

        /// <summary>
        /// sorts books in the list using the specified comparison function.
        /// </summary>
        /// <param name="comparer">implementation to use when comparing elements</param>
        /// <exception cref="ArgumentNullException">throws when comparer is nulll</exception>
        public void SortBooksByTag(IComparer<Book> comparer)
        {
            if (ReferenceEquals(comparer, null)) throw new ArgumentNullException($"{nameof(comparer)} is null");
            books.Sort(comparer);
        }

        /// <summary>
        /// gets books from strorage
        /// </summary>
        /// <param name="storage">instance of storage class</param>
        /// <exception cref="ArgumentNullException">throws when storage is null</exception>
        public void GetFromStorage(IBookStorage storage)
        {
            if (ReferenceEquals(storage, null)) throw new ArgumentNullException($"{nameof(storage)} is null");
            foreach (var book in storage.GetBooks())
            {
                Add(book);
            }
            logger.Debug(DateTime.Now, "Get", $"books were got from storage");
        }

        /// <summary>
        /// saves books to strorage
        /// </summary>
        /// <param name="storage">instance of storage class</param>
        /// <exception cref="ArgumentNullException">throws when storage is null</exception>
        public void SaveToStorage(IBookStorage storage)
        {
            if (ReferenceEquals(storage, null)) throw new ArgumentNullException($"{nameof(storage)} is null");
            storage.SaveBooks(books);
            logger.Debug(DateTime.Now, "Save", $"books were saved to storage");
        }

    }
}
