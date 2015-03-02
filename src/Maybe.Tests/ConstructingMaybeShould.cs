using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using FluentAssertions;
using Xunit;

namespace Maybe.Tests
{
    public class ConstructingMaybeShould
    {
        [Fact]
        public void BePrivateAffair()
        {
            var constructors = typeof (Maybe<>).GetConstructors(
                BindingFlags.Public | BindingFlags.Static |
                BindingFlags.NonPublic | BindingFlags.Instance);

            constructors.Should().NotBeEmpty();
            constructors.Should().OnlyContain(x => x.IsPrivate);
        }
    }
}
