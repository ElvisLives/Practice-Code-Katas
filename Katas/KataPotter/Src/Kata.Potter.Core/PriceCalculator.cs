using System;
using System.Collections.Generic;
using System.Linq;
using Kata.Potter.Core.Discount;
using Kata.Potter.Core.Model;

namespace Kata.Potter.Core
{
    public class PriceCalculator
    {
        private IDiscountLocator _discountLocator;

        public PriceCalculator(IDiscountLocator locator)
        {
            _discountLocator = locator;
        }

        public double CalculatePriceFor(Cart cart)
        {
            IList<Book> discountedBooks = ApplyDiscounts(cart.Books);
            return discountedBooks.Select(x => x.Price).Sum();
        }

        private IList<Book> ApplyDiscounts(IList<Book> books)
        {
            return books;
        }
    }
}