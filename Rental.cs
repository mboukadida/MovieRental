using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRental
{
    public class Rental
    {
        public Rental(int daysRented, Movie movie)
        {
            DaysRented = daysRented;
            Movie = movie;
        }

        public Movie Movie { get; }
        public int DaysRented { get; }
    }
}
