using FluentAssertions;
using FluentAssertions.Primitives;

namespace Addressbook.Tests.ValueObjects
{
    public static class AssertionHelper
    {
        public static AndConstraint<StringAssertions> NoneFails()
        {
            return "x".Should().Be("y");
        }

        public static AndConstraint<StringAssertions> NoneIsTrue()
        {
            return "x".Should().Be("x");
        }
    }
}