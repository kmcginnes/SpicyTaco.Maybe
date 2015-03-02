using System;
using FluentAssertions;
using Xunit;

namespace Maybe.Tests
{
    public class ConstructingMaybeShould
    {
        [Fact]
        public void BePrivateAffair()
        {
            var constructors = typeof (Maybe<>).Constructors();

            constructors.Should().NotBeEmpty();
            constructors.Should().OnlyContain(x => x.IsPrivate);
        }
    }

    public class EmptyMaybeShould
    {
        [Fact]
        public void ReturnSameInstanceEachTime()
        {
            var first = Maybe<String>.Empty;
            var second = Maybe<String>.Empty;

            first.Should().BeSameAs(second);
        }

        [Fact]
        public void NotHaveValue()
        {
            Maybe<String>.Empty.HasValue.Should().BeFalse();
        }

        [Fact]
        public void ThrowWhenAccessingValue()
        {
            Action act = () => { var v = Maybe<String>.Empty.Value; };

            act.ShouldThrow<InvalidOperationException>();
        }
    }
}
