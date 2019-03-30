## Railway Oriented Programming

Funktionale Programmierung wird oft als das "Zusammenstöpseln" von Funktionen dargestellt...

----

Beispiel:

```
f1: Eingabe string, Ausgabe int
f2: Eingabe int, Ausgabe bool

FP: Komposition von f1 und f2
f3: Eingabe string, Ausgabe bool
```

```
// FP Syntax
f1: string -> int
f2: int -> bool
f3: string -> bool
```

----

```csharp
// Klassisch ===========================================================
int F1(string s) => int.TryParse(s, out var i) ? i : 0;
bool F2(int i) => i > 0;

F2(F1("1")) // -> true
F2(F1("0")) // -> false

// "composition"
bool F3(string s) => F2(F1(s));

// Method Chaining =====================================================
// using C# extension methods (must be in static class)
static int F1(this string s) => int.TryParse(s, out var i) ? i : 0;
static bool F2(this int i) => i > 0;

// Viel Lesbarer
"1".F1().F2() // ->true
"0".F1().F2() // ->false

// Viel Lesbarer
bool F3(string s) => s.F1().F2();
```

----

Mehr Inhalt von railway-notes

