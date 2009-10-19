using System.Collections.Generic;
using FizzWare.NBuilder;
using Kata.Potter.Core.Discount;
using Kata.Potter.Core.Model;
using Machine.Specifications;
using Xunit;

namespace Kata.Potter.CoreTests
{
    public class DiscountSpecificationTests
    {
        private IDiscount discount = new Discount(0);
        [Fact]
        public void Two_Different_Books_Should_Satisfy_Specification()
        {
            IList<Book> books = Builder<Book>.CreateListOfSize(2)
                .WhereTheFirst(1).IsConstructedWith("First Title", 10)
                .WhereTheLast(1).IsConstructedWith("Second Title", 10)
                .Build();
            new DiscountSpecification(2, discount).IsSatisfiedBy(books).ShouldBeTrue();
        }

        [Fact]
        public void Two_Of_The_Same_Books_Should_Not_Satisfy_Specification()
        {
            IList<Book> books = Builder<Book>.CreateListOfSize(2)
                .WhereAll().AreConstructedWith("Title", 10)
                .Build();
            new DiscountSpecification(2, discount).IsSatisfiedBy(books).ShouldBeFalse();
        }

        [Fact]
        public void Three_Different_Books_Should_Satisfy_Specification()
        {
            IList<Book> books = Builder<Book>.CreateListOfSize(3)
                .WhereTheFirst(1).IsConstructedWith("First Title", 10)
                .WhereAll().AreConstructedWith("Second Title", 10)
                .WhereTheLast(1).IsConstructedWith("Third Title", 10)
                .Build();
            new DiscountSpecification(2, discount).IsSatisfiedBy(books).ShouldBeTrue();
        }

        [Fact]
        public void Three_Books_Where_Two_Are_The_Same_Book_Should_Satisfy_Specification()
        {
            IList<Book> books = Builder<Book>.CreateListOfSize(3)
                .WhereTheFirst(1).IsConstructedWith("First Title", 10)
                .WhereTheLast(2).IsConstructedWith("Second Title", 10)
                .Build();
            new DiscountSpecification(2, discount).IsSatisfiedBy(books).ShouldBeTrue();
        }

        [Fact]
        public void Three_Of_The_Same_Books_Should_Not_Satisfy_Specifcation()
        {
            IList<Book> books = Builder<Book>.CreateListOfSize(3)
                .WhereAll().AreConstructedWith("Title", 10)
                .Build();
            new DiscountSpecification(2, discount).IsSatisfiedBy(books).ShouldBeFalse();
        }
    }
}