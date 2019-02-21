using CSharpFunctionalExtensions;

namespace ContactList.Tests
{
    public class EmailAddress3Tests
    {
        static class MaybeTestExtensions
        {

            // workaround (no "this")
            public static MaybeAssertions<T1> Should<T1>(Maybe<T1> instance)
            {
                return new MaybeAssertions<T1>(instance);
            }
        }

        public class MaybeAssertions<T1>
        {
            private Maybe<T1> instance;

            public MaybeAssertions(Maybe<T1> instance)
            {
                this.instance = instance;
            }

            public bool IsOkAndEquals(string value)
            {
                return instance.HasValue && instance.Value.Equals(value);
            }
        }
    }
}