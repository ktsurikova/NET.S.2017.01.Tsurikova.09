using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Book : IEquatable<Book>
    {
        public int Id { get; }
        public string Name { get; }
        public string Author { get; }
        public int YearOfPublication { get; }

        public Book(int id, string name, string author, int year)
        {
            Id = id;
            Name = name;
            Author = author;
            YearOfPublication = year;
        }

        public bool Equals(Book other)
        {
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (Id != other.Id) return false;
            if (!string.Equals(Name, other.Name)) return false;
            if (!string.Equals(Author, other.Author)) return false;
            return YearOfPublication == other.YearOfPublication;
        }

        public override string ToString() => $"№{Id} '{Name}' of {Author}, {YearOfPublication}";

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null) || !(obj is Book)) return false;
            return Equals((Book)obj);
        }

        public override int GetHashCode()
        {
            return Id + 31 * Name.GetHashCode() + 31 * Author.GetHashCode() +
                   31 * YearOfPublication;
        }
    }
}
