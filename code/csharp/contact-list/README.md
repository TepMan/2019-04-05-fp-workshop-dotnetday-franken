# Initial Setup

```
dotnet new sln -n ContactList
dotnet new xunit -o ContactList.Tests
dotnet new classlib -o ContactList
cd ContactList.Tests && dotnet add reference ../ContactList/ContactList.csproj && dotnet add package FluentAssertions&& cd ..
dotnet sln add ContactList/ContactList.csproj
dotnet sln add ContactList.Tests/ContactList.Tests.csproj
dotnet test
```
