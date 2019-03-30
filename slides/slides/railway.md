## Railway Oriented Programming

Funktionale Programmierung wird oft als das zusammenstöpseln von Funktionen dargestellt.

Beispiel:

f1: Eingabe string, Ausgabe int
f2: Eingabe int, Ausgabe bool

FP: Komposition von f1 und f2
f3: Eingabe string, Ausgabe bool

FP Syntax
f1: string -> int
f2: int -> bool
f3: string -> bool


```csharp
// Pseudocode
int F1(string s) => int.TryParse(s, out var i) ? i : 0;

bool F2(int i) => i > 0;

F2(F1("1")) // -> true
F2(F1("1")) // -> false

// composition
bool F3(string s) => F2(F1(s));

F3("1") // -> true
F3("0") // -> false

// method chaining using C# extension methods (must be in static class)
static int F1(this string s) => int.TryParse(s, out var i) ? i : 0;

static bool F2(this int i) => i > 0;

"1".F1().F2() // ->true
"0".F1().F2() // ->false

// composition
bool F3(string s) => s.F1().F2();
```

Fazit: Funktionen sind einfach zu verketten, da die Ausgabe einer Funktion der Eingabe der folgenden Funktion entsprechen.

Problem: Keine standartisierte Strategie für Fehlerbehandlung 

Wenn wir davon ausgehen, dass Funktionen auch einen Fehlerfall haben, benoetigen wir einen neuen Datentyp, der das abbilden kann.

"Result" kann entweder das korrekte/erwartete Ergebniss beinhalten, oder aber einen Fehlerfall.

In Railway-Sprech bedeutet dass, dass man "2-gleissig" faehrt:

Jede Funktion bekommt eine Eingabe, und hat "im Bauch" eine Weiche, die entscheidet ob auf das Fehlergleis oder auf das Erfolgsgleis umgeschaltet wird.

Wenn man nun versucht Funktionen, die sowohl einen Erfolgs- als auch einen Fehlerfall zurueckgeben, zu verketten, schlaegt der uebliche FP-Mechanismus der Komposition fehl, da die Funktionen (bisher) nur den Erfolgsfall als Eingabe erlauben.

In anderen Worten: die Funktionen haben aktuell 1 Eingabe (1 Gleis), und 2 Ausgaben (2 Gleise).

Man benoetigt also einen Mechanismus, der eine 2-gleisige Eingabe so umwandelt, dass eine Funktion, die eine 1-gleisige Eingabe erwartet, damit umgehen kann.

Was muss dieser Mechanismus koennen?

- wenn die Eingabe fehlerhaft ist, muss die Funktion nichts tun, und kann den Fehler weiterreichen
- wenn die Eingabe nicht fehlerhaft ist, wird der Wert an die Funktion gegeben

FP-Jargon: dieser Mechanismus wird als `bind` bezeichnet.

bind: (string -> Result int) -> Result string -> Result int

bind: (a -> M b) -> M a -> M b

FP-Jargon: eine Wrapper-Klasse, die `bind` bereitstellt, wird Monade genannt (sehr stark vereinfacht!).

Beispiel: siehe `ChainingOptions.Chaining_option_returning_functions`.

FP-Jargon: Railway vs FP

FP: Either-Monade
Railway: Result

Either besteht aus 2 Teilen:
- Left
- Right (right bedeutet im Englischen auch "richtig"...)

Result besteht aus 2 Teilen:
- Failure
- Success

Either/Result ist aehnlich zu Option: Option hat `Some` und `None`. `None` wird durch einen eigenen Typen dargestellt (frei waehlbar, zB selbst definierter Error Typ).


