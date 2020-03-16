using System;

namespace MovieRental
{
    public class Movie
    {
       
        public const int CHILDRENS = 0;
        public const int REGULAR = 1;
        public const int NEW_RELEASE = 2;

        public string Title { get; }

        private Price _price;
        public int PriceCode => _price.GetPriceCode();

        public Movie(string title, int priceCode)
        {
            Title = title;
            SetPriceCode(priceCode);
        }

        private void SetPriceCode(int priceCode)
        {
            _price = priceCode switch
            {
                REGULAR => new RegularPrice(),
                CHILDRENS => new ChildrenPrice(),
                NEW_RELEASE => new NewReleasePrice(),
                _ => throw new ArgumentOutOfRangeException(nameof(priceCode))
            };
        }

        public double GetCharge(int daysRented)
        {
            return _price.GetCharge(daysRented);
        }

        public int GetFrequentRenterPoints(int daysRented)
        { 
// add frequent renter points
// add bonus for a two day new release rental

            return _price.GetFrequentRenterPoints(daysRented);
           
        }
    }
}
