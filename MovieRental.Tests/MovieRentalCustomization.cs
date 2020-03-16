using AutoFixture;
using AutoFixture.AutoMoq;

namespace MovieRental.Tests
{
    public class MovieRentalCustomization : CompositeCustomization
    {
        public MovieRentalCustomization()
            : base(new AutoMoqCustomization { ConfigureMembers = true},
                new OmitOnRecursionCustomization())
        {
        }
    }
}