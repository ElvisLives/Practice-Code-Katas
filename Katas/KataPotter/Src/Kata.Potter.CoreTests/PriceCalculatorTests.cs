using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kata.Potter.Core;
using Kata.Potter.Core.Discount;
using Kata.Potter.Core.Model;
using Machine.Specifications;
using Rhino.Mocks;
using Xunit;

namespace Kata.Potter.CoreTests
{
    public class PriceCalculatorTests
    {
        [Fact]
        public void When_Calculating_The_Price_Of_An_Empty_Cart_Price_Should_Be_Zero()
        {
            var locator = MockRepository.GenerateStub<IDiscountLocator>();
            var item = new PriceCalculator(locator);
            
            var expected = 0;
            var actual = item.CalculatePriceFor(new Cart());

            actual.ShouldEqual(expected);
        }

        [Fact]
        public void When_Calculating_The_Price_Of_One_Book_Price_Should_Be_Book_Price()
        {
            var cart = new Cart();
            var locator = MockRepository.GenerateStub<IDiscountLocator>();
            var item = new PriceCalculator(locator);
            var expected = 10;

            cart.AddBook(new Book("",10));
            var actual = item.CalculatePriceFor(cart);

            actual.ShouldEqual(expected);
        }

        [Fact]
        public void When_Calculating_The_Price_Of_Two_Books_Price_Should_Be_The_Sum_Of_Books_Price()
        {
            var cart = new Cart();
            var locator = MockRepository.GenerateStub<IDiscountLocator>();
            var item = new PriceCalculator(locator);
            var expected = 20;

            cart.AddBook(new Book("",10));
            cart.AddBook(new Book("",10));
            var actual = item.CalculatePriceFor(cart);

            actual.ShouldEqual(expected);
        }
    }
}
