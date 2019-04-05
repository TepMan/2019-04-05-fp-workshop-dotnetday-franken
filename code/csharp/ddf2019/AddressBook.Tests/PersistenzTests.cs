using FluentAssertions;
using LaYumba.Functional;
using Xunit;

namespace AddressBook.Tests
{
    public class PersistenzTests
    {
        [Fact]
        public void SaveAndSendMessageReturnsErrorWhenInputIsNotX()
        {
            var input = "y";
            Either<string, string> saveAndSendMessage = input.SaveAndSendMessage();

            saveAndSendMessage.Match(
                variableName0=> variableName0.Should().Be("Saving to database failed."), 
                variableNAme1 => true.Should().BeFalse());

        }
    }
}