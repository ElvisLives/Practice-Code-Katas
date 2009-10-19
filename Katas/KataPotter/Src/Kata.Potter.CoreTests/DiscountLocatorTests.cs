using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kata.Potter.Core.Discount;
using Kata.Potter.Core.Model;
using Machine.Specifications;
using Rhino.Mocks;
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

            var discounts = locator.GetDiscountsFor(cart);

            discounts.Count().ShouldEqual(0);
        }

        [Fact]
        public void Single_Book_Should_Locate_No_Discounts()
        {
            var cart = new Cart();
            var repo = new DiscountSpecificationRepository();
            var locator = new DiscountLocator(repo);

            cart.AddBook(new Book("", 8));

            var discounts = locator.GetDiscountsFor(cart);

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

            var discounts = locator.GetDiscountsFor(cart);

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

            var discounts = locator.GetDiscountsFor(cart);

            discounts.Count().ShouldEqual(1);
        }
    }
}
