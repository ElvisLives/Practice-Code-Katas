using Kata.Potter.Core.Model;
using Machine.Specifications;
using Xunit;

namespace Kata.Potter.CoreTests
{
    public class BookTests
    {
        [Fact]
        public void Two_Books_With_The_Same_Name_Should_Be_Equal()
        {
            var book1 = new Book("title1", 0);
            var book2 = new Book("title1", 0);

            book1.ShouldEqual(book2);
        }

        [Fact]
        public void Two_Books_With_The_Same_Title_And_Different_Prices_Should_Be_Equal()
        {
            var book1 = new Book("title1", 10);
            var book2 = new Book("title1", 20);

            book1.ShouldEqual(book2);
        }

        [Fact]
        public void Two_Books_With_Different_Titles_Should_Not_Be_Equal()
        {
            var book1 = new Book("title1", 0);
            var book2 = new Book("title2", 0);

            book1.ShouldNotEqual(book2);
        }
    }
}