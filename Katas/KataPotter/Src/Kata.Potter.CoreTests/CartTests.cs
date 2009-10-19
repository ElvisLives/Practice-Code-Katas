using System.Linq;
using Kata.Potter.Core.Model;
using Machine.Specifications;
using Xunit;

namespace Kata.Potter.CoreTests
{
  public class CartTests
  {
    [Fact]
    public void Adding_A_Book_To_A_Cart_Should_Add_Book_To_Books_Collection()
    {
      var book = new Book("", 0);
      var cart = new Cart();

      cart.AddBook(book);

      cart.Books.First().ShouldEqual(book);
    }
  }
}