using Kata.Potter.Core.Model;
using Kata.Potter.CoreTests.Specifications.Contexts;
using Machine.Specifications;

namespace Kata.Potter.CoreTests.Specifications
{
    [Subject("calculating prices")]
    public class when_calculating_the_full_price_of_one_book : with_no_discounts
    {
         Establish context = () => cart.AddBook(new Book("", 10));

         Because of = () => { price = calculator.CalculatePriceFor(cart); };

         It should_return_the_full_price_of_the_book = () => price.ShouldEqual(10);
    }

    [Subject("calculating prices")]
    public class when_calculating_the_ful_price_of_many_books : with_no_discounts
    {
         Establish context = () =>
                                        {
                                            cart.AddBook(new Book("", 10));
                                            cart.AddBook(new Book("", 10));
                                        };

         Because of = () => { price = calculator.CalculatePriceFor(cart); };

         It should_return_the_full_price_of_all_books = () => price.ShouldEqual(20);
    }

    [Subject("calculating discount prices")]
    public class when_calculating_the_price_of_a_book : with_discounts
    {
         Establish context = () =>
                                        {
                                            cart.AddBook(new Book("", 8));
                                            correctPrice = 8;
                                        };

         Because of = () => { price = calculator.CalculatePriceFor(cart); };

         It should_return_the_full_price_of_the_book = () => price.ShouldEqual(correctPrice);
    }

    [Subject("calculating discount prices")]
    public class when_calculating_the_price_of_two_different_books : with_discounts
    {
         Establish context = () =>
                                        {
                                            cart.AddBook(new Book("Book 1", 8));
                                            cart.AddBook(new Book("Book 2", 8));
                                            correctPrice = 8*2 - (8*2*0.05);
                                        };

         Because of = () => { price = calculator.CalculatePriceFor(cart); };

         It should_apply_a_five_percent_discount = () => price.ShouldEqual(correctPrice);
    }

    [Subject("calculating discount prices")]
    public class when_calculating_the_price_of_three_different_books : with_discounts
    {
         Establish context = () =>
                                        {
                                            cart.AddBook(new Book("Book 1", 8));
                                            cart.AddBook(new Book("Book 2", 8));
                                            cart.AddBook(new Book("Book 3", 8));
                                            correctPrice = 8*3 - (8*3*0.1);
                                        };

         Because of = () => { price = calculator.CalculatePriceFor(cart); };

         It should_apply_a_ten_percent_discount = () => price.ShouldEqual(correctPrice);
    }

    [Subject("calculating discount prices")]
    public class when_calculating_the_price_of_four_different_books : with_discounts
    {
         Establish context = () =>
                                        {
                                            cart.AddBook(new Book("Book 1", 8));
                                            cart.AddBook(new Book("Book 2", 8));
                                            cart.AddBook(new Book("Book 3", 8));
                                            cart.AddBook(new Book("Book 4", 8));
                                            correctPrice = 8*4 - (8*4*0.2);
                                        };

         Because of = () => { price = calculator.CalculatePriceFor(cart); };

         It should_apply_a_twenty_percent_discount = () => price.ShouldEqual(correctPrice);
    }

    [Subject("calculating discount prices")]
    public class when_calculating_the_price_of_five_different_books : with_discounts
    {
         Establish context = () =>
                                        {
                                            cart.AddBook(new Book("Book 1", 8));
                                            cart.AddBook(new Book("Book 2", 8));
                                            cart.AddBook(new Book("Book 3", 8));
                                            cart.AddBook(new Book("Book 4", 8));
                                            cart.AddBook(new Book("Book 5", 8));
                                            correctPrice = 8*5 - (8*5*0.25);
                                        };

         Because of = () => { price = calculator.CalculatePriceFor(cart); };

         It should_apply_a_twenty_five_percent_discount = () => price.ShouldEqual(correctPrice);
    }

    [Subject("calculating discount prices")]
    public class when_calculating_the_price_of_four_books_where_two_are_the_same : with_discounts
    {
         Establish context = () =>
                                        {
                                            cart.AddBook(new Book("Book 1", 8));
                                            cart.AddBook(new Book("Book 2", 8));
                                            cart.AddBook(new Book("Book 3", 8));
                                            cart.AddBook(new Book("Book 3", 8));
                                            correctPrice = (8*3 - (8*3*0.1)) + 8;
                                        };

         Because of = () => { price = calculator.CalculatePriceFor(cart); };

         It should_apply_a_twenty_percent_discount_to_three_of_the_books = () =>
                                                                                  price.ShouldEqual(correctPrice);
    }

    [Subject("calculating discount prices")]
    public class when_calculating_the_price_of_the_kata_example_set_of_books : with_discounts
    {
         Establish context = () =>
                                        {
                                            cart.AddBook(new Book("Book 1", 8));
                                            cart.AddBook(new Book("Book 1", 8));
                                            cart.AddBook(new Book("Book 2", 8));
                                            cart.AddBook(new Book("Book 2", 8));
                                            cart.AddBook(new Book("Book 3", 8));
                                            cart.AddBook(new Book("Book 3", 8));
                                            cart.AddBook(new Book("Book 4", 8));
                                            cart.AddBook(new Book("Book 5", 8));
                                            correctPrice = 51.2;
                                        };

         Because of = () => { price = calculator.CalculatePriceFor(cart); };

         It should_calculate_the_correct_price = () => price.ShouldEqual(correctPrice);
    }
}