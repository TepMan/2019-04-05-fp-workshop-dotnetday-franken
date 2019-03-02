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

# Continuous testing in vscode

- install plugin `.NET Core Test Explorer`
- enabling auto-watch: File -> Preferences -> Settings -> Extensions -> .NET Core Test Explorer -> switch tab to `Workspace settings` -> check AutoWatch
- This feature might complain that dotnet watch is not installed: Install it: 
`dotnet tool install --global dotnet-watch`.

- next error: MSBuild missing:
```
dotnet watch test --logger "trx;LogFileName=/tmp/test-explorer-cVSnmp/autoWatch.trx"
watch : Could not find a MSBuild project file in '/home/patrick/Documents/talks/2019-04-05-fp-workshop-dotnetday-franken/code/csharp/addressbook'. Specify which project to use with the --project option.
```

According to this [Github issue](https://github.com/aspnet/DotNetTools/issues/452) adding the following should work:

`dotnet-test-explorer.testProjectPath": ".Tests/"`

Be sure to restart vscode for these changes to take effect.
