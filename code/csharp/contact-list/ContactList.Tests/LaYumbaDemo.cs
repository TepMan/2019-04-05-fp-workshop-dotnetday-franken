using System;
using static System.Math;
using FluentAssertions;
using LaYumba.Functional;
using Xunit;
using static LaYumba.Functional.F;
using Unit = System.ValueTuple;     // <- don't use void!!
using FluentAssertions.Primitives;

namespace ContactList.Tests
{
    // From "Functional Programming with C#"
    public class LaYumbaDemo
    {
        // ========================================================================================
        // Chapter 3: Option (requires pattern matchin)
        public void ScratchOption()
        {
        }

        [Fact]
        public void Using_pattern_matching()
        {
            string greetClassic(string greetee)
                => greetee == null
                    ? "Sorry, who?"
                    : $"Hello, {greetee}";

            greetClassic(null).Should().Be("Sorry, who?");
            greetClassic("dodnedder").Should().Be($"Hello, dodnedder");


            string greet(Option<string> greetee)
                => greetee.Match(
                    None: () => "Sorry, who?",
                    Some: (name) => $"Hello, {name}");

            // string greetCompact(Option<string> greetee)
            //     => greetee.Match(
            //         () => "Sorry, who?",
            //         (name) => $"Hello, {name}");

            Option<string> none = None;
            Option<string> dodnedder = Some("dodnedder");

            greet(none).Should().Be("Sorry, who?");
            greet(dodnedder).Should().Be("Hello, dodnedder");
        }

        // Listing 3.8 Smart constructor pattern
        public struct Age
        {
            public int Value { get; }

            // smart ctor
            public static Option<Age> Of(int age)
                => IsValid(age) ? Some(new Age(age)) : None;

            private Age(int value)
            {
                if (!IsValid(value))
                    throw new ArgumentException($"{value} is not a valid age");
                Value = value;
            }

            private static bool IsValid(int age)
                => 0 <= age && age < 120;
        }

        [Fact]
        public void Age_has_smart_ctor()
        {
            // TODO Create readable test extension for Option
            Age.Of(10).Match(
                () => true.Should().Be(false),
                (age) => age.Value.Should().Be(10));

            Age.Of(-1).Match(
                () => true.Should().Be(true),
                (age) => age.Should().Be(null));
        }

        // ========================================================================================
        // Chapter 4: Map, Bind, Where and ForEach; Functors and Monads

        // 4.1 Applying a function to a structure's inner value

        // Listing 4.1 Map for IEnumerable<T>
        /*
            public static IEnumerable<R> Map<T, R>
                (this IEnumerable<T> ts, Func<T, R> f)
            {
                foreach (var t in ts)
                    yield return f(t);
            }
         */

        // FP-JARGON: Map == Linq's Select

        // Map Signature for IEnumerable:   (IEnumerable<T>, (T -> R)) -> IEnumerable<R>

        // Porting the principle to Option: (Option<T>,      (T -> R)) -> Option<R>

        /*
            // Handle None case
            public static Option<R> Map<T, R>
                (this Option.None _, Func<T, R> f)
                    => None;

            // Handle Some case
            public static Option<R> Map<T, R>
                (this Option.Some<T> some, Func<T, R> f)
                    => Some(f(some.Value));                    

            // Combined
            public static Option<R> Map<T, R>
                (this Option<T> optT, Func<T, R> f)
                    => optT.Match(
                        () => None,
                        (t) => Some(f(t)));                    
         */

        // Abstract pattern: Map ("C" short for "Container"): 
        //          (C<T>, (T -> R)) -> C<R>
        //
        // FP-JARGON: This is called a Functor
        //
        // Why is a functor not an interface? C# does not support HKTs! See Box on page 86

        // ForEach: Used for performing side-effects! 
        // This similar to the difference between Action and Func:
        //  Action has no return value -> must be performing a side-effect)

        // 4.3 Bind: Chaining functions which return a Container
        //
        //      Abstract pattern: Bind ("C" short for "Container"):
        //          (C<T>, (T -> C<R>)) -> C<R>
        //
        // FP-JARGON: This is called a Monad
        //
        // FP-JARGON: Bind == Linq's SelectMany
        //
        // Listing 4.3 Comparing Map and Bind
        /*
            public static Option<R> Bind<T, R>
                (this Option<T> optT, Func<T, Option<R>> f) // <- Bind takes an Option-returning function!
                    => optT.Match(
                        () => None,
                        (t) => f(t));

            public static Option<R> Map<T, R>
                (this Option<T> optT, Func<T, R> f) // <- Map takes a regular function!
                    => optT.Match(
                        () => None,
                        (t) => Some(f(t)));     
         */

        // Listing 4.4 Using Bind to compose two functions that return an Option
        [Fact]
        public void BindDemo()
        {
            // Int.Parse is a function from LaYumba. It takes a string and returns an Option<int>.
            // Int.Parse: s -> Option<int>
            Option<int> optI = Int.Parse("12");

            // Age.Of: int -> Option<Age>
            // Age.Of(1)

            // Combination with Map:
            var ageOpt = optI.Map(i => Age.Of(i));

            // Problem: returns Option<Option<Age>> ARRGH!
            Option<Option<Age>> ageOpt1 = optI.Map(i => Age.Of(i));

            // Solution: Bind instead of Map when combining functions which return M<T>
            Func<string, Option<Age>> parseAge = s
                => Int.Parse(s).Bind(Age.Of);

            var ageO = parseAge("12");
            ageO.Match(
                None: () => true.Should().Be(false), // <- ensure that this path is never called!
                Some: x => x.Value.Should().Be(12)
            );
        }

        // 4.3.2 Flattening nested lists with Bind

        /*
            public static IEnumerable<R> Bind<T, R>
                (this IEnumerable<T> ts, Func<T, IEnumerable<R>> f)
            {
                foreach (T t in ts)
                    foreach (R r in f(t))
                        yield return r;
            }
         */

        // Previous example is the same as Linq SelectMany!

        // FP-JARGON: Filter, Map; page 94
        /*
            LaYumba.Functional              LINQ                Common synonyms
            ------------------              ----                ---------------
            Map                             Select              fMap, Project, Lift
            Bind                            SelectMany          FlatMap, Chain, Collect, Then
            Where                           Where               Filter
            ForEach                         n/a                 Iter
         */

        // FP-JARGON: Fig. 4.4, Fig. 4.5, Fig. 4.6

        // ========================================================================================
        // Chapter 5: Function composition, method chaining, functional domain modelling
        // TODO

        // ========================================================================================
        // Chapter 6: Functional error handling
        // - Either
        public void ScratchEither()
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