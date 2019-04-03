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

            var incomes = new List<int>();
            foreach (var person in people)
            {
                if (person.Age > 25)
                {
                    incomes.Add(person.Income);
                }
            }

            var numberOfEntries = incomes.Count;
            var totalTmp = incomes.Sum();
            var avg = totalTmp / numberOfEntries;

            // Assert
            averageIncomeAbove25.Should().Be(1200);
            avg.Should().Be(1200);
        }
    }

    public class Person
    {
        public int Age { get; set; }
        public int Income { get; set; }
    }
}