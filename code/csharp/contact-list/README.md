# Initial Setup

(on Windows: replace `\` with `^` as line continuation)

```
dotnet new sln -n ContactList
dotnet new xunit -o ContactList.Tests
dotnet new classlib -o ContactList
cd ContactList.Tests && \
    dotnet add reference ../ContactList/ContactList.csproj && \
    dotnet add package FluentAssertions && \
    cd ..
dotnet sln add ContactList/ContactList.csproj
dotnet sln add ContactList.Tests/ContactList.Tests.csproj
dotnet test
```

Adding `CSharpFunctionalExtensions`:
```
cd ContactList
dotnet add package CSharpFunctionalExtensions
cd ../ContactList.Tests
dotnet add package CSharpFunctionalExtensions
```

# Functional libraries for C#

- [CSharpFunctionalExtensions](https://github.com/vkhorikov/CSharpFunctionalExtensions): Basics, production ready
- [la-yumba](https://github.com/la-yumba/functional-csharp-code): Basics, production ready, used in book "Functional Programming in C#"
- [language-ext](https://github.com/louthy/language-ext): Full in FP, hardcore, almost Haskell (functor, monad, pattern matching, HKT)

