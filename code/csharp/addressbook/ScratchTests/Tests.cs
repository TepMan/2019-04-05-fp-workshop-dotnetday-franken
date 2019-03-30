using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;
using LaYumba.Functional;
using static LaYumba.Functional.F;


namespace ScratchTests
{
    public class Tests
    {
        public class FunctionalComposition
        {
            int F1(string s) => int.TryParse(s, out var i) ? i : 0;
            bool F2(int i) => i > 0;

            [Fact]
            public void Functional_composition_old_school()
            {
                F2(F1("1")).Should().BeTrue();
                F2(F1("0")).Should().BeFalse();
            }

            [Fact]
            public void Functional_composition_method_chaining()
            {
                "1".F1().F2().Should().BeTrue();
                "0".F1().F2().Should().BeFalse();
            }
        }


        public class OptionDemo
        {
            Option<string> DoMagic(string s) => s.Length < 5 ? Some(s) : None;

            [Theory]
            [InlineData("1", true)]
            [InlineData("123456", false)]
            public void Option_always_exists(string s, bool expected)
            {
                DoMagic(s).Should().BeOfType<Option<string>>();

                // DON'T DO THIS (`GetOrElse`)!
                // FP ANTIPATTERN!
                // USE PATTERN MATCHING INSTEAD!
                DoMagic(s).GetOrElse("ups")
                    .Should().Be(expected ? s : "ups");
            }
        }

        public class PatternMatching
        {
            private static Option<string> IsNonEmpty(string s)
                => string.IsNullOrWhiteSpace(s)
                    ? None
                    : Some(s);

            [Fact]
            public void PatternMatchingIntro()
            {
                var opt = IsNonEmpty("a");

                var result = opt.Match(
                    () => "string is empty",
                    x => x);

                result.Should().Be("a");
            }
        }


        public class ChainingOptions
        {
            Option<string> F1(string s) => s.Length < 5 ? Some(s) : None;
            Option<string> F2(string s) => s.StartsWith("a") ? Some(s) : None;

            [Fact]
            public void Chaining_option_returning_functions()
            {
                var optF1 = F1("s");

                // F2(optF1); // <-- does not work

                // Does Map help?
                // Map: (a -> b) -> Option(a) -> Option(b)
                //
                // Here:
                // F2               -> Option(Option(b))
                // (a -> Option(b)) -> Option(a) -> Option(Option(b))
                // Rueckgabewert von F2 ist Option(b), nicht b! -> Verschachteltes Option<Option<b>>
                var rMap = optF1.Map(x => F2(x));
                rMap.Should().BeOfType<Option<Option<string>>>();

                // Bind to the rescue!
                // Bind: (a -> Option(b)) -> Option(a) -> Option(b)
                var result = optF1.Bind(F2);
                result.Should().BeOfType<Option<string>>();

                // Unterschied Map und Bind
                // Map:  (a -> b)         -> Option(a) -> Option(b)
                // Bind: (a -> Option(b)) -> Option(a) -> Option(b)

                // Wie sieht Bind aus?
                optF1.MyBindStringToString(F2);
                
                // oder etwas allgemeiner..
                optF1.MyBind(F2);

            }
        }
    }

    public static class FunctionalCompositionExtensions
    {
        public static int F1(this string s) => int.TryParse(s, out var i) ? i : 0;
        public static bool F2(this int i) => i > 0;


        //public static TResult MyMap<TSource, TResult>
        //    (this TSource src, Func<TSource, TResult> func)
        //{
        //    return func(src);
        //}

    }

    public static class MySimpleFuncExtensions
    {
        public static Option<string> MyBindStringToString(
            this Option<string> optS, 
            Func<string, Option<string>> func)
        {
            return optS.Match(
                () => None,
                x => func(x));
        }

        public static Option<TResult> MyBind<TSource, TResult>(
            this Option<TSource> optS, 
            Func<TSource, Option<TResult>> func)
        {
            return optS.Match(
                () => None,
                x => func(x));
        }
    }
}
