using System;
using FluentAssertions;
using Xunit;

namespace SpicyTaco.Maybe.Tests
{
    public class DoWhenEmptyShould
    {
        [Fact]
        public void PerformActionWhenNothing()
        {
            var wasCalled = false;
            Nothing<String>.Instance.DoWhenEmpty(() => wasCalled = true);
            wasCalled.Should().BeTrue();
        }

        [Fact]
        public void NotPerformActionWhenJust()
        {
            var wasCalled = false;
            "Some string".ToMaybe().DoWhenEmpty(() => wasCalled = true);
            wasCalled.Should().BeFalse();
        }
    }
}