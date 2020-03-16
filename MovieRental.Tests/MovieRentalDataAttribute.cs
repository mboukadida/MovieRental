using AutoFixture;
using AutoFixture.NUnit3;

namespace MovieRental.Tests
{
    public class MovieRentalDataAttribute: AutoDataAttribute
    {
        public MovieRentalDataAttribute()
            : base(() => new Fixture()
                .Customize(new MovieRentalCustomization())
            )
        {
        }
    }
}