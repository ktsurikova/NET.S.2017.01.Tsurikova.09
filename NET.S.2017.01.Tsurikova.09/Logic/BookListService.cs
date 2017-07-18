using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.storage;

namespace Logic
{
    public class BookListService : IEnumerable<Book>
    {
        private List<Book> books;

        public BookListService()
        {
            books = new List<Book>();
        }

        public void Add(Book book)
        {
            if (ReferenceEquals(book, null)) throw new ArgumentNullException($"{nameof(book)} is null");
            if (!books.Contains(book))
                books.Add(book);
            else throw new BookStrorageException("strorage already contains this book");
        }

        public void Remove(Book book)
        {
            if (ReferenceEquals(book, null)) throw new ArgumentNullException($"{nameof(book)} is null");
            if (!books.Contains(book))
                throw new BookStrorageException("storage doesn't contain such book");
            books.Remove(book);
        }

        public Book FindBookByTag(Predicate<Book> tag) => books.Find(tag);

        public void SortBooksByTag(IComparer<Book> comparer)
        {
            if (ReferenceEquals(comparer, null)) throw new ArgumentNullException($"{nameof(comparer)} is null");
            books.Sort(comparer);
        }

        public IEnumerator<Book> GetEnumerator() => books.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void GetFromStorage(IBookListStorage storage)
        {
            if (ReferenceEquals(storage, null)) throw new ArgumentNullException($"{nameof(storage)} is null");
            books = storage.GetBooks();
        }

        public void SaveToStorage(IBookListStorage storage)
        {
            if (ReferenceEquals(storage, null)) throw new ArgumentNullException($"{nameof(storage)} is null");
            storage.SaveBooks(books);
        }

    }
}
