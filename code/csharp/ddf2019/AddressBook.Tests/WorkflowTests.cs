using System.Linq;
using FluentAssertions;
using LaYumba.Functional;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Xunit;

namespace AddressBook.Tests
{
    public class WorkflowTests
    {
        [Fact]
        public void Invalid_first_and_last_name_errors_are_returned_correctly()
        {
            Validation<string> validation = Workflow.Validate("y", "y");
            validation.Match(
                erList => erList.Select(x => x.Message).Should().HaveCount(2)
                    .And.ContainEquivalentOf("invalid last name")
                    .And.ContainEquivalentOf("invalid first name"),
                success => success.Should().HaveLength(0));
        }
    }
}