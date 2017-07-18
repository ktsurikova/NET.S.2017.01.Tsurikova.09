using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// class for working with book info
    /// </summary>
    public class Book : IEquatable<Book>
    {
        public int Id { get; }
        public string Name { get; }
        public string Author { get; }
        public int YearOfPublication { get; }

        /// <summary>
        /// initializes new instance of the class using the source data
        /// </summary>
        /// <param name="id">id of book</param>
        /// <param name="name">name of book</param>
        /// <param name="author">author of book</param>
        /// <param name="year">year of publication of book</param>
        public Book(int id, string name, string author, int year)
        {
            Id = id;
            Name = name;
            Author = author;
            YearOfPublication = year;
        }

        /// <summary>
        /// returns value indicating whether the given instance is equal to the specified object
        /// </summary>
        /// <param name="other">object that is compared to this instance</param>
        /// <returns>true if equals, otherwise false</returns>
        public bool Equals(Book other)
        {
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (Id != other.Id) return false;
            if (!string.Equals(Name, other.Name)) return false;
            if (!string.Equals(Author, other.Author)) return false;
            return YearOfPublication == other.YearOfPublication;
        }

        /// <summary>
        /// converts the value of this instance to string
        /// </summary>
        /// <returns>string whose value is the same as this instance</returns>
        public override string ToString() => $"№{Id} '{Name}' of {Author}, {YearOfPublication}";

        /// <summary>
        /// returns value indicating whether the given instance is equal to the specified object
        /// </summary>
        /// <param name="obj">object that is compared to this instance</param>
        /// <returns>true if equals, otherwise false</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null) || !(obj is Book)) return false;
            return Equals((Book)obj);
        }

        /// <summary>
        /// returns the hash code for this instance
        /// </summary>
        /// <returns>a 32-bit signed integer hash code</returns>
        public override int GetHashCode()
        {
            return Id + 31 * Name.GetHashCode() + 31 * Author.GetHashCode() +
                   31 * YearOfPublication;
        }
    }
}
