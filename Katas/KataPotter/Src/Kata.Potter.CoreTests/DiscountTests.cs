using System.Collections.Generic;
using FizzWare.NBuilder;
using Kata.Potter.Core.Discount;
using Kata.Potter.Core.Model;
using Machine.Specifications;
using Xunit;

namespace Kata.Potter.CoreTests
{
    public class DiscountTests
    {

        [Fact]
        public void Two_Different_Books_Should_Satisfy_Specification()
        {
            IList<Book> books = Builder<Book>.CreateListOfSize(2)
                .WhereTheFirst(1).IsConstructedWith("First Title", 10).Have(x => x.IsDiscounted = false)
                .WhereTheLast(1).IsConstructedWith("Second Title", 10).Have(x => x.IsDiscounted = false)
                .Build();
            new Discount(2, 0).IsSatisfiedBy(books).ShouldBeTrue();
        }

        [Fact]
        public void Two_Of_The_Same_Books_Should_Not_Satisfy_Specification()
        {
            IList<Book> books = Builder<Book>.CreateListOfSize(2)
                .WhereAll().AreConstructedWith("Title", 10)
                .Build();
            new Discount(2, 0).IsSatisfiedBy(books).ShouldBeFalse();
        }

        [Fact]
        public void Three_Different_Books_Should_Satisfy_Specification()
        {
            IList<Book> books = Builder<Book>.CreateListOfSize(3)
                .WhereTheFirst(1).IsConstructedWith("First Title", 10)
                .WhereAll().AreConstructedWith("Second Title", 10).Have(x => x.IsDiscounted = false)
                .WhereTheLast(1).IsConstructedWith("Third Title", 10)
                .Build();
            new Discount(2, 0).IsSatisfiedBy(books).ShouldBeTrue();
        }

        [Fact]
        public void Three_Books_Where_Two_Are_The_Same_Book_Should_Satisfy_Specification()
        {
            IList<Book> books = Builder<Book>.CreateListOfSize(3)
                .WhereTheFirst(1).IsConstructedWith("First Title", 10).Have(x => x.IsDiscounted = false)
                .WhereTheLast(2).IsConstructedWith("Second Title", 10).Have(x => x.IsDiscounted = false)
                .Build();
            new Discount(2, 0).IsSatisfiedBy(books).ShouldBeTrue();
        }

        [Fact]
        public void Three_Of_The_Same_Books_Should_Not_Satisfy_Specifcation()
        {
            IList<Book> books = Builder<Book>.CreateListOfSize(3)
                .WhereAll().AreConstructedWith("Title", 10).Have(x => x.IsDiscounted = false)
                .Build();
            new Discount(2, 0).IsSatisfiedBy(books).ShouldBeFalse();
        }
    }
}