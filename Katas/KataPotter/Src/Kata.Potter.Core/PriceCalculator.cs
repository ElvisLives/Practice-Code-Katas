using System.Collections.Generic;
using System.Linq;
using Kata.Potter.Core.Discount;
using Kata.Potter.Core.Model;

namespace Kata.Potter.Core
{
  public class PriceCalculator
  {
    private readonly IDiscounter _discounter;

    public PriceCalculator(IDiscounter discounter)
    {
      _discounter = discounter;
    }

    public decimal CalculatePriceFor(Cart cart)
    {
      IList<Book> discountedBooks = ApplyDiscounts(cart.Books);
      return discountedBooks.Sum(x => x.Price);
    }

    private IList<Book> ApplyDiscounts(IList<Book> books)
    {
      return _discounter.ApplyDiscounts(books);
    }
  }
}