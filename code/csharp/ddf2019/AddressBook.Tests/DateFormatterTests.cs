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

        [Fact]
        public void CutTimeWorks()
        {
            var input = Some(new DateTime(2019, 4, 5, 12, 34, 56));
            input.CutTime().Match(
                () => true.Should().BeFalse(),
                dt => dt.Hour.Should().Be(0));
        }

        [Fact]
        public void CutTimeNoneValue()
        {
            Option<DateTime> input = None;
            input.CutTime().Match(
                () => true.Should().BeTrue(),
                dt => dt.Hour.Should().Be(0));
        }
    }
}