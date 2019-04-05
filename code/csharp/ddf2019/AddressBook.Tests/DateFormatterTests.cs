using System;
using FluentAssertions;
using LaYumba.Functional;
using static LaYumba.Functional.F;
using Xunit;

namespace AddressBook.Tests
{
    public class DateFormatterTests
    {
        [Fact]
        public void FormatterTest()
        {
            var input = Some(new DateTime(2019, 04, 05));
            var result = DateFormatter.Format(input);
            result.Should().Be("05.04.2019");
        }
        [Fact]
        public void FormatterTestNone()
        {
            Option<DateTime> input = None;
            //var result = DateFormatter.Format(input);
            var result = input.Format();
            result.Should().Be("");
        }
    }
}