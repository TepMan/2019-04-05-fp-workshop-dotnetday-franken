## FP 101

- **Functions as First Class Citizens**
- Immutability
- Pure Functions (see Immutability)

That's it!

---

#### Immutability in C# #


```csharp
public class Customer
{
  public string Name { get; set; } // set -> mutable :-(
}
```

vs

```csharp
public class Customer
{
  public Customer(string name)
  {
    Name = name;
  }
  
  public string Name { get; } // <- immutable
}
```

---

Syntax matters!

Classic C#

```csharp
int Add(int a, int b)
{
  return a + b;
}
```

Expression body

```csharp
int Add(int a, int b) => a + b;
```
---

Syntax matters!

Classic C#

```csharp
int Add(int a, int b)
{
  Console.WriteLine("bla"); // <- side effect!
  return a + b;
}
```

Expression body: side effects are less likely

```csharp
int Add(int a, int b) => a + b;
```

---

#### 1st class functions in C# #


```csharp
// Func as parameter
public string Greet(Func<string, string> greeterFunction, string name)
{
  return greeterFunction(name);
}
```

```csharp
Func<string, string> formatGreeting = (name) => $"Hello, {name}";
var greetingMessage = Greet(formatGreeting, "dodnedder");
// -> greetingMessage: "Hello, dodnedder"
```

---

#### Pure Functions in C# #

- haben niemals Seiteneffekte!
- sollten immer nach `static` umwandelbar sein

---

Und was hat es mit

Filter / Map / Reduce

auf sich?

```csharp
var people = new List<Person> {
  new Person { Age = 20, Income = 1000 },
  new Person { Age = 26, Income = 1100 },
  new Person { Age = 35, Income = 1300 }
}

// Deklarativ: "Was will ich erreichen?"
// (nicht imperativ: "Wie erreiche ich etwas?")
// -> Keine For-Schleife(n)..
var averageIncomeAbove25 = people
  .Where(x => x.Age > 25) // "Filter"
  .Select(x => x.Income)  // "Map"
  .Average();             // "Reduce"
```

---

Schränken uns diese FP Paradigmen ein?

---

Wie kann man mit diesem "Purismus" Software schreiben, die etwas tut?

---

## Kleine Funktionen zu größeren verbinden

- Gängige Vorgehensweise: Kleine Funktionen werden zu immer größeren Funktionalitäten zusammengesteckt
- Problem: Nicht alle Funktionen passen gut zusammen
- Zu Lösungsmöglichkeiten dafür kommen wir später noch
