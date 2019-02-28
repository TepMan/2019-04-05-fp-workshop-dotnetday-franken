using System;
using FluentAssertions;
using LaYumba.Functional;
using Xunit;

namespace Addressbook.Tests.Helper
{
    public class ParserTests
    {
        [Fact]
        public void FactMethodName()
        {
            var option = "2019-01-01".Parse();
            
            option.Should().BeOfType<Option<DateTime>>();
            
            option.Match(
                None: () => false.Should().BeTrue(),
                Some: x => x.Should().Be(new DateTime(2019, 1, 1)));
        }
    }
}