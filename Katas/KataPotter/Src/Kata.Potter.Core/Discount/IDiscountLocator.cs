using System;
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
        private readonly IDiscountRepository _factory;

        public DiscountLocator(IDiscountRepository factory)
        {
            _factory = factory;
        }

        public IEnumerable<IDiscount> GetDiscountsFor(IList<Book> books)
        {
            return _factory.GetAllDiscounts()
                .Where(x => x.IsSatisfiedBy(books));
        }
    }
}