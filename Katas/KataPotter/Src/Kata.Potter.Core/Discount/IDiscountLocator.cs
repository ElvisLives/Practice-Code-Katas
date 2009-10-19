using System;
using System.Collections.Generic;
using System.Linq;
using Kata.Potter.Core.Model;

namespace Kata.Potter.Core.Discount
{
    public interface IDiscountLocator
    {
        IEnumerable<IDiscount> GetDiscountsFor(Cart cart);
    }

    public class DiscountLocator : IDiscountLocator
    {
        private readonly IDiscountRepository _factory;

        public DiscountLocator(IDiscountRepository factory)
        {
            _factory = factory;
        }

        public IEnumerable<IDiscount> GetDiscountsFor(Cart cart)
        {
            return _factory.GetAllDiscounts()
                .Where(x => x.IsSatisfiedBy(cart.Books))
                .Select(x => x.Discount);
        }
    }
}