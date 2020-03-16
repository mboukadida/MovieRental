using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRental
{
    public class Movie
    {
        public const int CHILDRENS = 0;
        public const int REGULAR = 1;
        public const int NEW_RELEASE = 2;

        public string Title { get; }
        public int PriceCode { get; set; }

        public Movie(string title, int priceCode)
        {
            Title = title;
            PriceCode = priceCode;
        }
    }
}
