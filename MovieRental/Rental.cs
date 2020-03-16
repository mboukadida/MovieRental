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

        public double GetCharge()
        {
            return Movie.GetCharge(DaysRented);
        }

        public int GetFrequentRenterPoints()
        {
            return Movie.GetFrequentRenterPoints(DaysRented);
        }
    }
}
