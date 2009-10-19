using System;

namespace Kata.Potter.Core.Model
{
  public class Book : IEquatable<Book>, ICloneable
  {
    public Book(string title, double price)
    {
      Title = title;
      Price = price;
      IsDiscounted = false;
    }

    public string Title { get; private set; }
    public double Price { get; set; }
    public bool IsDiscounted { get; set; }

    #region IEquatable<Book> Members

    public bool Equals(Book other)
    {
      if(ReferenceEquals(null, other)) return false;
      if(ReferenceEquals(this, other)) return true;
      return Equals(other.Title, Title);
    }

    #endregion

    public override bool Equals(object obj)
    {
      if(ReferenceEquals(null, obj)) return false;
      if(ReferenceEquals(this, obj)) return true;
      if(obj.GetType() != typeof(Book)) return false;
      return Equals((Book) obj);
    }

    public override int GetHashCode()
    {
      unchecked
      {
        return ((Title != null ? Title.GetHashCode() : 0) * 397);
      }
    }

    public object Clone()
    {
      return new Book(Title, Price) { IsDiscounted = IsDiscounted};
    }
  }
}