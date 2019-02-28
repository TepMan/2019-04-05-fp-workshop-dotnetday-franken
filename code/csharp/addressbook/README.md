# Initial Setup

(on Windows: replace `\` with `^` as line continuation)

```
dotnet new sln -n Addressbook
dotnet new xunit -o Addressbook.Tests
dotnet new classlib -o Addressbook
cd Addressbook.Tests && \
    dotnet add reference ../Addressbook/Addressbook.csproj && \
    dotnet add package FluentAssertions && \
    cd ..
dotnet sln add Addressbook/Addressbook.csproj
dotnet sln add Addressbook.Tests/Addressbook.Tests.csproj
dotnet test
```

Adding `CSharpFunctionalExtensions`:
```
cd Addressbook
dotnet add package CSharpFunctionalExtensions
cd ../Addressbook.Tests
dotnet add package CSharpFunctionalExtensions
```

# Functional libraries for C#

- [CSharpFunctionalExtensions](https://github.com/vkhorikov/CSharpFunctionalExtensions): Basics, production ready
- [la-yumba](https://github.com/la-yumba/functional-csharp-code): Basics, production ready, used in book "Functional Programming in C#"
- [language-ext](https://github.com/louthy/language-ext): Full in FP, hardcore, almost Haskell (functor, monad, pattern matching, HKT)

