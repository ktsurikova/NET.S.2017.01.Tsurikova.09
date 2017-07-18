using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.storage;

namespace Logic
{
    /// <summary>
    /// class providing functions for working with books
    /// </summary>
    public class BookListService : IEnumerable<Book>
    {
        private List<Book> books;

        /// <summary>
        /// initializes new instance of the class
        /// </summary>
        public BookListService()
        {
            books = new List<Book>();
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
        }

        /// <summary>
        /// Searches for a book that matches the conditions specified predicate
        /// </summary>
        /// <param name="tag">delegate defining the conditions for the search for an element</param>
        /// <returns>the first element satisfying the conditions specified predicate</returns>
        public Book FindBookByTag(Predicate<Book> tag) => books.Find(tag);

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
        /// returns an enumerator that enumerates books
        /// </summary>
        /// <returns>enumerator that enumerates books</returns>
        public IEnumerator<Book> GetEnumerator() => books.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// gets books from strorage
        /// </summary>
        /// <param name="storage">instance of storage class</param>
        /// <exception cref="ArgumentNullException">throws when storage is null</exception>
        public void GetFromStorage(IBookListStorage storage)
        {
            if (ReferenceEquals(storage, null)) throw new ArgumentNullException($"{nameof(storage)} is null");
            books = storage.GetBooks();
        }

        /// <summary>
        /// saves books to strorage
        /// </summary>
        /// <param name="storage">instance of storage class</param>
        /// <exception cref="ArgumentNullException">throws when storage is null</exception>
        public void SaveToStorage(IBookListStorage storage)
        {
            if (ReferenceEquals(storage, null)) throw new ArgumentNullException($"{nameof(storage)} is null");
            storage.SaveBooks(books);
        }

    }
}
