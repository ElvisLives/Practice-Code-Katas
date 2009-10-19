using System.Collections.Generic;
using System.Linq;
using Kata.Potter.Core.Extensions;
using Kata.Potter.Core.Model;

namespace Kata.Potter.Core.Discount
{
  public interface IDiscounter
  {
    IList<Book> ApplyDiscounts(IList<Book> books);
  }

  public class Discounter : IDiscounter
  {
    private readonly IDiscountLocator _locator;

    public Discounter(IDiscountLocator locator)
    {
      _locator = locator;
    }

    #region IDiscounter Members

    public IList<Book> ApplyDiscounts(IList<Book> books)
    {
      var discounts = _locator.GetDiscountsFor(books)
        .OrderBy(x => x.Percentage);

      var bestDiscountedBooks = books;

      for(int i = 0; i <= discounts.Count(); i++)
      {
       var testDiscountBooks = books.Clone();

        foreach(IDiscount discount in discounts.Take(i).OrderByDescending(x => x.Percentage))
        {
          while(discount.IsSatisfiedBy(testDiscountBooks))
            discount.Apply(testDiscountBooks);
        }

        if(testDiscountBooks.Sum(x => x.Price) < bestDiscountedBooks.Sum(x => x.Price))
          bestDiscountedBooks = testDiscountBooks;
      }

      return bestDiscountedBooks;
    }

    #endregion
  }
}