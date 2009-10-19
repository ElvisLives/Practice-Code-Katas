using System.Collections.Generic;
using System.Linq;
using Kata.Potter.Core.Discount;
using Kata.Potter.Core.Model;
using Machine.Specifications;
using Xunit;

namespace Kata.Potter.CoreTests
{
  public class DiscountLocatorTests
  {
    [Fact]
    public void Empty_Cart_Should_Locate_No_Discounts()
    {
      var cart = new Cart();
      var repo = new DiscountSpecificationRepository();
      var locator = new DiscountLocator(repo);

      IEnumerable<IDiscount> discounts = locator.GetDiscountsFor(cart.Books);

      discounts.Count().ShouldEqual(0);
    }

    [Fact]
    public void Single_Book_Should_Locate_No_Discounts()
    {
      var cart = new Cart();
      var repo = new DiscountSpecificationRepository();
      var locator = new DiscountLocator(repo);

      cart.AddBook(new Book("", 8));

      IEnumerable<IDiscount> discounts = locator.GetDiscountsFor(cart.Books);

      discounts.Count().ShouldEqual(0);
    }

    [Fact]
    public void Two_Of_The_Same_Book_Should_Locate_No_Discounts()
    {
      var cart = new Cart();
      var repo = new DiscountSpecificationRepository();
      var locator = new DiscountLocator(repo);

      cart.AddBook(new Book("", 8));
      cart.AddBook(new Book("", 8));

      IEnumerable<IDiscount> discounts = locator.GetDiscountsFor(cart.Books);

      discounts.Count().ShouldEqual(0);
    }

    [Fact]
    public void Two_Different_Books_Should_Locate_One_Discount()
    {
      var cart = new Cart();
      var repo = new DiscountSpecificationRepository();
      var locator = new DiscountLocator(repo);

      cart.AddBook(new Book("Book 1", 8));
      cart.AddBook(new Book("Book 2", 8));

      IEnumerable<IDiscount> discounts = locator.GetDiscountsFor(cart.Books);

      discounts.Count().ShouldEqual(1);
    }
  }
}