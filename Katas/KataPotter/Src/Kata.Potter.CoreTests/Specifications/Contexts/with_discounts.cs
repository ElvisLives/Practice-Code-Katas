using Kata.Potter.Core;
using Kata.Potter.Core.Discount;
using Kata.Potter.Core.Model;
using Machine.Specifications;

namespace Kata.Potter.CoreTests.Specifications.Contexts
{
  public class with_discounts
  {
    public static PriceCalculator calculator;
    public static Cart cart = new Cart();
    public static double correctPrice;
    public static IDiscounter discounter;
    public static IDiscountLocator locator;
    public static double price;
    public static IDiscountRepository repo;

    private Establish context = () =>
                                  {
                                    cart = new Cart();
                                    repo = new DiscountSpecificationRepository();
                                    locator = new DiscountLocator(repo);
                                    discounter = new Discounter(locator);
                                    calculator = new PriceCalculator(discounter);
                                  };
  }
}