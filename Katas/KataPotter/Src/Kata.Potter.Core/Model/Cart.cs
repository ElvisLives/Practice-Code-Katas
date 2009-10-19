using System.Collections.Generic;

namespace Kata.Potter.Core.Model
{
  public class Cart
  {
    public Cart()
    {
      Books = new List<Book>();
    }

    public IList<Book> Books { get; private set; }

    public void AddBook(Book book)
    {
      Books.Add(book);
    }
  }
}