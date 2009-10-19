using System.Collections.Generic;
using System.Linq;
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
      IEnumerable<IDiscount> discounts = _locator.GetDiscountsFor(books)
        .OrderByDescending(x => x.Percentage);

      foreach(IDiscount discount in discounts)
      {
        while(discount.IsSatisfiedBy(books))
        {
          discount.Apply(books);
        }
      }

      return books;
    }

    #endregion
  }
}