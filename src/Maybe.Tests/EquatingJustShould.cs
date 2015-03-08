using FluentAssertions;
using Xunit;

namespace SpicyTaco.Maybe.Tests
{
    public class EquatingJustShould
    {
        [Fact]
        public void BeEqualWhenBothAreOfSameTypeAndValue()
        {
            var left = "Some string".ToMaybe();
            var right = "Some string".ToMaybe();

            // TODO: This doesn't work... WHY???
            // var result = left == right;
            var result = left.Equals(right);

            result.Should().BeTrue();
        }

        [Fact]
        public void NotBeEqualWhenBothAreOfSameTypeButDifferentValues()
        {
            var left = "Some string".ToMaybe();
            var right = "Some string2".ToMaybe();

            var result = left == right;

            result.Should().BeFalse();
        }
    }
}