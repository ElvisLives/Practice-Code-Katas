using Kata.Potter.Core;
using Kata.Potter.Core.Discount;
using Kata.Potter.Core.Model;
using Machine.Specifications;
using Rhino.Mocks;

namespace Kata.Potter.CoreTests.Specifications.Contexts
{
  public class with_no_discounts
  {
    public static PriceCalculator calculator;
    public static Cart cart = new Cart();
    public static IDiscounter discounter;
    public static decimal price;

    private Establish context = () =>
                                  {
                                    cart = new Cart();
                                    discounter = MockRepository.GenerateStub<IDiscounter>();
                                    discounter.Expect(x => x.ApplyDiscounts(null)).IgnoreArguments().Return(cart.Books);
                                    calculator = new PriceCalculator(discounter);
                                  };
  }
}