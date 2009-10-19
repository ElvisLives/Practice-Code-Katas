using System;
using System.Collections.Generic;
using Kata.Potter.Core.Model;

namespace Kata.Potter.Core.Discount
{
    public interface IDiscount
    {
        double Percentage { get; }
        IDiscountSpecification Specification { get; set; }
        void Apply(IList<Book> books);
    }

    public class Discount : IDiscount
    {
        private readonly double _percentage;

        public Discount(double percentage)
        {
            _percentage = percentage;
        }

        #region IDiscount Members

        public double Percentage
        {
            get { return _percentage; }
        }

        public IDiscountSpecification Specification { get; set; }

        public void Apply(IList<Book> books)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}