using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Logic.storage
{
    public class BookStrorageException : Exception
    {
        public BookStrorageException()
        {
        }

        public BookStrorageException(string message) : base(message)
        {
        }

        public BookStrorageException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BookStrorageException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
