using System.Collections.Generic;

namespace Kata.Potter.Core.Discount
{
  public interface IDiscountRepository
  {
    IEnumerable<IDiscount> GetAllDiscounts();
  }

  public class DiscountSpecificationRepository : IDiscountRepository
  {
    #region IDiscountRepository Members

    public IEnumerable<IDiscount> GetAllDiscounts()
    {
      return new List<IDiscount>
               {
                 new Discount(2, .05M),
                 new Discount(3, .1M),
                 new Discount(4, .2M),
                 new Discount(5, .25M)
               };
    }

    #endregion
  }
}