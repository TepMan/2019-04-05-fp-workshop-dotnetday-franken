using System;
using static System.Math;
using FluentAssertions;
using LaYumba.Functional;
using Xunit;
using static LaYumba.Functional.F;
using Unit = System.ValueTuple;     // <- don't use void!!

namespace ContactList.Tests
{
    // From "Functional Programming with C#"
    public class LaYumbaDemo
    {
        // Chapter 3: Option
        // Chapter 4: Map, Bind, Where and ForEach; Functors and Monads
        // Chapter 5: Function composition, method chaining, functional domain modelling
        
        // Chapter 6: Functional error handling
        // - Either
        public void Scratch()
        {
            // Either
            var r = Right(12);
            var l = Left("ups");
        }

        string Render(Either<string, double> val) =>
            val.Match(
                Left: l => $"Invalid value: {l}",
                Right: r => $"The result is: {r}");

        [Fact]
        public void RenderTest()
        {
            Render(Right(12d)).Should().Be("The result is: 12");
            Render(Left("ups")).Should().Be("Invalid value: ups");
        }

        // Listing 6.1
        // f(x, y) -> sqrt(x / y)
        Either<string, double> Calc(double x, double y)
        {
            if (y == 0) return "y cannot be 0";
            if (x != 0 && Sign(x) != Sign(y))
                return "x / y cannot be negative";
            return Sqrt(x / y);
        }

        [Fact]
        public void CalcTest()
        {
            // TODO Is there a easier way to test an Either??
            Calc(3, 0).Match(
                Left: e => e.Should().Be("y cannot be 0"),
                Right: r => r.Should().Be(null));

            Calc(-3, 3).Match(
                Left: e => e.Should().Be("x / y cannot be negative"),
                Right: r => r.Should().Be(null));

            Calc(-3, -3).Match(
                Left: e => e.Should().Be(null),
                Right: r => r.Should().Be(1));
        }

        // Listing 6.2 (using Option)
        Option<Candidate> RecruitmentProcess1(Candidate candidate,
            Func<Candidate, bool> IsEligible,
            Func<Candidate, Option<Candidate>> TechTest,
            Func<Candidate, Option<Candidate>> Interview)
                => Some(candidate)
                    .Where(IsEligible)
                    .Bind(TechTest)         // <- TODO Explain Bind
                    .Bind(Interview);       // <- TODO Explain Bind

        [Fact]
        public void RecruitmentProcess1Test()
        {
            // Arrange
            Func<Candidate, bool> IsEligible = candidate => true;
            Func<Candidate, Option<Candidate>> TechTest = candidate => Some(candidate);
            Func<Candidate, Option<Candidate>> Interview = candidate => Some(candidate);

            // Act
            var optionalCandidate = RecruitmentProcess1(new Candidate("homer"), IsEligible, TechTest, Interview);

            // Assert
            optionalCandidate.Map(c => c.Name.Should().Be("homer"));
        }

        // Listing 6.3 (using Either instead of Option)
        Either<Rejection, Candidate> RecruitmentProcess2(
            Candidate candidate,
            Func<Candidate, Either<Rejection, Candidate>> CheckEligibility,
            Func<Candidate, Either<Rejection, Candidate>> TechTest,
            Func<Candidate, Either<Rejection, Candidate>> Interview)
                => Right(candidate)
                    .Bind(CheckEligibility) // <- TODO explain Bind
                    .Bind(TechTest)         // <- TODO explain Bind
                    .Bind(Interview);       // <- TODO explain Bind

        [Fact]
        public void RecruitmentProcess2Test()
        {
            // Arrange
            Func<Candidate, bool> IsEligible = candidate => true;
            Func<Candidate, Either<Rejection, Candidate>> TechTest = candidate => Right(candidate);
            Func<Candidate, Either<Rejection, Candidate>> Interview = candidate => Right(candidate);
            Either<Rejection, Candidate> CheckEligibility(Candidate c)
            {
                if (IsEligible(c)) return c;
                else return new Rejection("Not eligible");
            }
        
            // Act
            var optionalCandidate = RecruitmentProcess2(
                new Candidate("homer simpson"), 
                CheckEligibility, TechTest, Interview);

            // Assert
            optionalCandidate.Map(candidate => candidate.Name.Should().Be("homer simpson"));
        }

        // Listing 6.4
        private void Chaining_Either()
        {
            Func<Either<Reason, Unit>> WakeUpEarly;
            Func<Unit, Either<Reason, Ingredients>> ShopForIngredients;
            Func<Ingredients, Either<Reason, Food>> CookRecipe;
            Action<Food> EnjoyTogether;
            Action<Reason> ComplainAbout;
            Action OrderPizza;
            
            /*
                 o WakeUpEarly
                / \
               L   R ShopForIngredients
                  / \
                 L   R CookRecipe
                    / \
                   L   R EnjoyTogether
            */

            void Start()
            {
                WakeUpEarly()
                .Bind(ShopForIngredients)
                .Bind(CookRecipe)
                .Match(
                    Right: dish => EnjoyTogether(dish),
                    Left: reason =>
                        {
                            ComplainAbout(reason);
                            OrderPizza();
                        });
            }
        }

        private class Candidate
        {
            public string Name { get; }

            public Candidate(string name)
            {
                this.Name = name;
            }
        }

        private class Rejection
        {
            public string Reason { get; }

            public Rejection(string reason)
            {
                this.Reason = reason;
            }
        }

        private class Reason
        {
        }

        private class Ingredients
        {
        }

        private class Food
        {
        }
    }

    // Only for reference: These functions are part of the library
    public static class EitherExtensions
    {
        // Core functions of Either: Map, ForEach, and Bind

        // Map
        // public static Either<L, RR> Map<L, R, RR>
        //     (this Either<L, R> either, Func<R, RR> f)
        //     => either.Match<Either<L, RR>>(
        //         l => Left(l),
        //         r => Right(f(r)));

        // // ForEach
        // public static Either<L, Unit> ForEach<L, R>
        //     (this Either<L, R> either, Action<R> act)
        //     => Map(either, act.ToFunc());

        // // Bind
        // public static Either<L, RR> Bind<L, R, RR>
        //     (this Either<L, R> either, Func<R, Either<L, RR>> f)
        //     => either.Match(
        //         l => Left(l),
        //         r => f(r));
    }
}