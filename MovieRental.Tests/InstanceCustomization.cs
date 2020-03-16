using System;
using AutoFixture;

namespace MovieRental.Tests
{
    public class InstanceCustomization<TSource> : ICustomization
    {
        private readonly Func<TSource> _function;

        public InstanceCustomization(Func<TSource> function)
        {
            _function = function ?? throw new ArgumentNullException(nameof(function));
        }

        public void Customize(IFixture fixture)
        {
            fixture.Register(_function);
        }
    }
}