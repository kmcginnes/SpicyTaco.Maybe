using System;
using FluentAssertions;
using Xunit;

namespace SpicyTaco.Maybe.Tests
{
    public class NothingShould
    {
        [Fact]
        public void HavePrivateConstructor()
        {
            var constructors = typeof (Nothing<>).Constructors();

            constructors.Should().NotBeEmpty();
            constructors.Should().OnlyContain(x => x.IsPrivate);
        }

        [Fact]
        public void BeOfTypeMaybe()
        {
            typeof (Nothing<String>).Should().BeAssignableTo<Maybe<String>>();
        }
    }
}
