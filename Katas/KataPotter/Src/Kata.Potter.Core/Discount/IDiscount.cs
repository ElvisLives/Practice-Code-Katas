using System.Collections.Generic;
using System.Linq;
using Kata.Potter.Core.Model;

namespace Kata.Potter.Core.Discount
{
  public interface IDiscount
  {
    double Percentage { get; }
    bool IsSatisfiedBy(IList<Book> books);
    void Apply(IList<Book> books);
  }

  public class Discount : IDiscount
  {
    private readonly int _bookCount;
    private readonly double _percentage;


    public Discount(int bookCount, double percentage)
    {
      _percentage = percentage;
      _bookCount = bookCount;
    }

    #region IDiscount Members

    public double Percentage
    {
      get { return _percentage; }
    }


    public void Apply(IList<Book> books)
    {
      books.Where(x => x.IsDiscounted == false).Distinct()
        .Take(_bookCount).ToList()
        .ForEach(DiscountBook);
    }

    public bool IsSatisfiedBy(IList<Book> books)
    {
      return books
        .Where(x => x.IsDiscounted == false)
        .Distinct()
        .Count() >= _bookCount;
    }

    #endregion

    private void DiscountBook(Book book)
    {
      book.Price = book.Price - (book.Price * _percentage);
      book.IsDiscounted = true;
    }
  }
}