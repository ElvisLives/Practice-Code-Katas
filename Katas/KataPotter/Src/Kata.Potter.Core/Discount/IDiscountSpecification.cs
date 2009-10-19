using System.Collections.Generic;
using System.Linq;
using Kata.Potter.Core.Model;

namespace Kata.Potter.Core.Discount
{
    public interface IDiscountSpecification
    {
        IDiscount Discount { get; }
        bool IsSatisfiedBy(IList<Book> books);
    }

    public class DiscountSpecification : IDiscountSpecification
    {
        private readonly int _bookCount;
        private readonly IDiscount _discount;

        public DiscountSpecification(int bookCount, IDiscount discount)
        {
            _bookCount = bookCount;
            _discount = discount;
            _discount.Specification = this;
        }

        public IDiscount Discount
        {
            get { return _discount; }
        }

        public bool IsSatisfiedBy(IList<Book> books)
        {
            return books.Distinct().Count() >= _bookCount;
        }
    }

}