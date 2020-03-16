using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using NUnit.Framework;

namespace MovieRental.Tests
{
    [TestFixture]
    [SuppressMessage("ReSharper", "NUnit.MethodWithParametersAndTestAttribute")]
    public class MovieRentalShould
    {
        [Test, MovieRentalData]
        public void PrintStatement_When_Asked(Customer sut)
        {
            // Given
            // When
            var result = sut.Statement();

            // Then
            result.Should().NotBeNull();
        }
    }
}