using AutoFixture;
using AutoFixture.Kernel;

namespace MovieRental.Tests
{
    public class TypeCustomization<TSource, TDestination> : ICustomization
        where TSource : class
        where TDestination : class
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customizations
                .Add(new TypeRelay(
                    typeof(TSource),
                    typeof(TDestination)));
        }
    }
}