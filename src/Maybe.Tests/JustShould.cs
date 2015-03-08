using FluentAssertions;
using Xunit;

namespace SpicyTaco.Maybe.Tests
{
    public class JustShould
    {
        [Fact]
        public void HavePrivateConstructor()
        {
            var constructors = typeof (Just<>).Constructors();

            constructors.Should().NotBeEmpty();
            constructors.Should().OnlyContain(x => x.IsPrivate);
        }

        [Fact]
        public void BeOfTypeMaybe()
        {
            typeof (Just<string>).Should().BeAssignableTo<Maybe<string>>();
        }
    }
}