using System.Collections.Generic;
using Kata.Potter.Core;
using Kata.Potter.Core.Discount;
using Kata.Potter.Core.Model;
using Machine.Specifications;
using Rhino.Mocks;

namespace Kata.Potter.CoreTests.Specifications.Contexts
{
    public class with_no_discounts
    {
        public static Cart cart = new Cart();
        public static IDiscountLocator locator;
        public static PriceCalculator calculator;
        public static double price;

        Establish context = () =>
                                {
                                    cart = new Cart();
                                    locator = MockRepository.GenerateStub<IDiscountLocator>();
                                    locator.Expect(x => x.GetDiscountsFor(null)).IgnoreArguments()
                                        .Return(new List<IDiscount>());
                                    calculator = new PriceCalculator(locator);
                                };
    }
}