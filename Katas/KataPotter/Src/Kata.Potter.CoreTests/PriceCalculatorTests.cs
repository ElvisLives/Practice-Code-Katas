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
      var cart = new Cart();
      var discounter = MockRepository.GenerateStub<IDiscounter>();
      discounter.Expect(x => x.ApplyDiscounts(null)).IgnoreArguments().Return(cart.Books);
      var item = new PriceCalculator(discounter);

      int expected = 0;
      decimal actual = item.CalculatePriceFor(cart);

      actual.ShouldEqual(expected);
    }

    [Fact]
    public void When_Calculating_The_Price_Of_One_Book_Price_Should_Be_Book_Price()
    {
      var cart = new Cart();
      var discounter = MockRepository.GenerateStub<IDiscounter>();
      discounter.Expect(x => x.ApplyDiscounts(null)).IgnoreArguments().Return(cart.Books);
      var item = new PriceCalculator(discounter);
      int expected = 10;

      cart.AddBook(new Book("", 10));
      decimal actual = item.CalculatePriceFor(cart);

      actual.ShouldEqual(expected);
    }

    [Fact]
    public void When_Calculating_The_Price_Of_Two_Books_Price_Should_Be_The_Sum_Of_Books_Price()
    {
      var cart = new Cart();
      var discounter = MockRepository.GenerateStub<IDiscounter>();
      discounter.Expect(x => x.ApplyDiscounts(null)).IgnoreArguments().Return(cart.Books);
      var item = new PriceCalculator(discounter);
      int expected = 20;

      cart.AddBook(new Book("", 10));
      cart.AddBook(new Book("", 10));
      decimal actual = item.CalculatePriceFor(cart);

      actual.ShouldEqual(expected);
    }
  }
}