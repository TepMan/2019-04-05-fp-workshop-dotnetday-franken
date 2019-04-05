using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using LaYumba.Functional;
using Xunit;

using static LaYumba.Functional.F;

namespace AddressBook.Tests
{
    public class Tests
    {
        [Fact]
        public void FilterMapReduce_imperative_Demo()
        {
            // Arrange
            var people = new List<Person>
            {
                new Person { Age = 20, Income = 1000 },
                new Person { Age = 26, Income = 1100 },
                new Person { Age = 35, Income = 1300 }
            };

            // Act
            var incomes = new List<int>();
            foreach (var person in people)
            {
                if (person.Age > 25)
                {
                    incomes.Add(person.Income);
                }
            }

            var avg = incomes.Sum() / incomes.Count;

            // Assert
            avg.Should().Be(1200);
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

        private class Person
        {
            public int Age { get; set; }
            public int Income { get; set; }
        }


        [Fact]
        public void Option_vs_Either_Demo()
        {
            Option<string> IsValidOpt(string s) =>
                string.IsNullOrEmpty(s)
                    ? None
                    : Some(s);

            // nasty cast
            Either<string, string> IsValidEither(string s)
                =>
                    string.IsNullOrEmpty(s)
                        ? (Either<string, string>) Left("ups")
                        : Right(s);

            //Either<string, string> IsValidEither(Option<string> optS)
            //    =>
            //        optS.Match(
            //            () => Left("ups"),
            //            x => Right(x));
        }

        class MyError
        {
            public string Message { get; set; }
        }
    }

}