using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.storage
{
    /// <summary>
    /// interface defining basic operations for working with storage
    /// </summary>
    public interface IBookListStorage
    {
        List<Book> GetBooks();
        void SaveBooks(List<Book> books);
    }
}
