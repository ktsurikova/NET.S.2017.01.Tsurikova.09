using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.storage
{
    public interface IBookListStorage
    {
        List<Book> GetBooks();
        void SaveBooks(List<Book> books);
    }
}
