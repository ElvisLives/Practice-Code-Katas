using System.Collections.Generic;
using System.Linq;
using Kata.Potter.Core.Model;

namespace Kata.Potter.Core.Discount
{
  public interface IDiscountLocator
  {
    IEnumerable<IDiscount> GetDiscountsFor(IList<Book> books);
  }

  public class DiscountLocator : IDiscountLocator
  {
    private readonly IDiscountRepository _repo;

    public DiscountLocator(IDiscountRepository repo)
    {
      _repo = repo;
    }

    #region IDiscountLocator Members

    public IEnumerable<IDiscount> GetDiscountsFor(IList<Book> books)
    {
      return _repo.GetAllDiscounts()
        .Where(x => x.IsSatisfiedBy(books));
    }

    #endregion
  }
}