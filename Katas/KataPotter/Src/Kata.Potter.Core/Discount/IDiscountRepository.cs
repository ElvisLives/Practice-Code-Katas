using System.Collections.Generic;

namespace Kata.Potter.Core.Discount
{
    public interface IDiscountRepository
    {
        IEnumerable<IDiscountSpecification> GetAllDiscounts();
    }

    public class DiscountSpecificationRepository : IDiscountRepository
    {
        #region IDiscountRepository Members

        public IEnumerable<IDiscountSpecification> GetAllDiscounts()
        {
            return new List<IDiscountSpecification>
                       {
                           new DiscountSpecification(2, new Discount(.05)),
                           new DiscountSpecification(3, new Discount(.1)),
                           new DiscountSpecification(4, new Discount(.2)),
                           new DiscountSpecification(5, new Discount(.25))
                       };
        }

        #endregion
    }
}