# Initial Setup

```
dotnet new sln -n ContactList
dotnet new xunit -o ContactList.Tests
dotnet new classlib -o ContactList
cd ContactList.Tests && dotnet add reference ../ContactList/ContactList.csproj && cd ..
dotnet sln add ContactList/ContactList.csproj
dotnet sln add ContactList.Tests/ContactList.Tests.csproj
dotnet restore
dotnet build
dotnet test
```
