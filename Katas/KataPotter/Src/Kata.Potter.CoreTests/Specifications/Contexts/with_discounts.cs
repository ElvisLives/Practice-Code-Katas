using System.Collections.Generic;
using Kata.Potter.Core;
using Kata.Potter.Core.Discount;
using Kata.Potter.Core.Model;
using Machine.Specifications;
using Rhino.Mocks;

namespace Kata.Potter.CoreTests.Specifications.Contexts
{
    public class with_discounts
    {
        public static Cart cart = new Cart();
        public static IDiscountRepository repo;
        public static IDiscountLocator locator;
        public static PriceCalculator calculator;
        public static double price;
        public static double correctPrice;

        Establish context = () =>
                                {
                                    cart = new Cart();
                                    repo = new DiscountSpecificationRepository();
                                    locator = new DiscountLocator(repo);
                                    calculator = new PriceCalculator(locator);
                                };
    }
}