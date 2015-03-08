using System;
using FluentAssertions;
using Xunit;

namespace SpicyTaco.Maybe.Tests
{
    public class DoShould
    {
        [Fact]
        public void NotPerformActionWhenNothing()
        {
            var wasCalled = false;
            Nothing<String>.Instance.Do(x => wasCalled = true);
            wasCalled.Should().BeFalse();
        }

        [Fact]
        public void PerformActionWhenJust()
        {
            var wasCalled = false;
            "Some string".ToMaybe().Do(x => wasCalled = true);
            wasCalled.Should().BeTrue();
        }
    }
}