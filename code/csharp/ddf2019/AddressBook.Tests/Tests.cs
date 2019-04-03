using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace AddressBook.Tests
{
    public class Tests
    {
        [Fact]
        public void SmokeTest()
        {
            true.Should().BeTrue();
            new Class1().SayHello("test").Should().Be("Hello, test!");

        }

        [Fact]
        public void FilterMapReduceDemo()
        {
            // Arrange
            var people = new List<Person>
            {
                new Person { Age = 20, Income = 1000 },
                new Person { Age = 26, Income = 1100 },
                new Person { Age = 35, Income = 1300 }
            };

            // Act
            var averageIncomeAbove25 = people
                .Where(x => x.Age > 25)
                .Select(x => x.Income)
                .Average();
            
            // Assert
            averageIncomeAbove25.Should().Be(1200);
        }
    }

    public class Person
    {
        public int Age { get; set; }
        public int Income { get; set; }
    }
}