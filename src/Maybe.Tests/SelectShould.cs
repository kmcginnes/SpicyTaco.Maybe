using System;
using FluentAssertions;
using Xunit;

namespace SpicyTaco.Maybe.Tests
{
    public class SelectShould
    {
        [Fact]
        public void ReturnNothingOfSelectedTypeWhenNothing()
        {
            Nothing<String>.Instance.Select(x => x.Length)
                .Should().BeOfType<Nothing<int>>();
        }

        [Fact]
        public void ReturnSelectedValueWhenJust()
        {
            "Some string".ToMaybe().Select(x => x.Length)
                .Should().Be(11.ToMaybe());
        }
    }

    // TODO: Finish this set of tests for flattening Maybe's
    public class SelectManyShould
    {
        [Fact]
        public void ReturnNothingOfSelectedTypeWhenNothing()
        {
            Nothing<String>.Instance.Select(x => x.Length)
                .Should().BeOfType<Nothing<int>>();
        }

        [Fact]
        public void ReturnSelectedValueWhenJust()
        {
            "Some string".ToMaybe().Select(x => x.Length)
                .Should().Be(11.ToMaybe());
        }
    }
}