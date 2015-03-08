using System;
using FluentAssertions;
using Xunit;

namespace SpicyTaco.Maybe.Tests
{
    public class BindShould
    {
        [Fact]
        public void ReturnNothingWhenNothing()
        {
            Nothing<String>.Instance.Bind(x => x.Length.ToMaybe())
                .Should().BeSameAs(Nothing<Int32>.Instance);
        }

        [Fact]
        public void ReturnBoundValueWhenJust()
        {
            "Some string".ToMaybe().Bind(x => x.Length.ToMaybe())
                .Should().Be(11.ToMaybe());
        }
    }
}