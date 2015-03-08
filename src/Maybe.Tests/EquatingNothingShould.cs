using System;
using FluentAssertions;
using Xunit;

namespace SpicyTaco.Maybe.Tests
{
    public class EquatingNothingShould
    {
        [Fact]
        public void BeEqualWhenBothAreNothingOfSameType()
        {
            var left = Nothing<String>.Instance;
            var right = Nothing<String>.Instance;

            var result = left == right;

            result.Should().BeTrue();
        }

        [Fact]
        public void NotBeEqualWhenBothAreNothingAndOfDifferentTypes()
        {
            var left = Nothing<String>.Instance;
            var right = Nothing<DateTime>.Instance;

            var result = left == right;

            result.Should().BeFalse();
        }

        [Fact]
        public void NotBeEqualWhenComparedToJust()
        {
            var left = Nothing<String>.Instance;
            var right = "Some string".ToMaybe();

            var result = left == right;

            result.Should().BeFalse();
        }
    }
}