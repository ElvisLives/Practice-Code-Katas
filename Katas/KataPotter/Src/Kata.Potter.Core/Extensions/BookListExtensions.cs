using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kata.Potter.Core.Model;

namespace Kata.Potter.Core.Extensions
{
  public static class BookListExtensions
  {
    public static IList<Book> Clone(this IList<Book> books)
    {
      var cloneList = new List<Book>();
      books.ToList().ForEach(x => cloneList.Add((Book)x.Clone()));
      return cloneList;
    }
  }
}
