---

## F#
- Ursprünglich: Microsoft Forschungsprojekt
- Heute: Community-driven
- inspiriert von OCaml
- Multi-Paradigma
- Fokus auf funktionale Programmierung im .NET Umfeld
- Statisch typisiert

---

## Besonderheiten
- Significant whitespace
- Reihenfolge der Definitionen in Datei wichtig
- Reihenfolge der Dateien im Projekt wichtig

--
## Immutability als Default
```fsharp
// Zuweisungen statt Variablen - unveränderlich (Immutability)
let x = 3
// Rechte Seite immer eine Expression - Wert, Funktion, ...
let add a b = a + b
let m = if 3 > 0 then 7 else 42

// Mutability nur auf Wunsch - normalerweise unnötig
let mutable y = 3
y <- 42
```

---
## Typ-Inferenz
```fsharp
// Typen werden automatisch abgeleitet sofern möglich
let double a = a * 2 // int -> int

// Explizite Angaben möglich
let doubleExplicit (a: int) : int = a * 2
```

---
## Currying
> Currying ist die Umwandlung einer Funktion mit mehreren Argumenten in eine Funktion mit einem Argument.
- ist ein Sprachfeature, das einige Sachen kompakter hinschreibbar macht
```fsharp
// int -> int -> int -> int
// eigentlich: int -> (int -> (int -> int))
let addThree a b c = a + b + c
```

---
## Partial Application
- Eine Funktion mit mehreren Parametern bekommt nur einen Teil ihrer Argumente übergeben - der Rest bleibt offen und kann später ausgefüllt werden
```fsharp
// Partial Application
let add a b = a + b // int -> (int -> (int))
let add2 = add 2 // (int -> (int))
let six = add2 4 // (int)
let ten = add2 8 // (int)
```

---

## Pipe-Operator
```fsharp
// der letzte Parameter kann mit dem Ergebnis der vorherigen Expression ausgefüllt werden
// "Pipe-Operator"
let double a = a * 2
4 |> double // ergibt 8
4 |> double |> double // ergibt 16
```

---
## Discriminated Unions
```fsharp
// Discriminated Unions ("Tagged Union", "Sum Type", "Choice Type")
type Vehicle = | Bike | Car | Bus

// Pattern Matching zur Behandlung der verschiedenen Fälle
let vehicle = Bike
match vehicle with
| Bike -> "Ima ridin my bike"
| Car -> "Driving along in my automobile"
| Bus -> "SPEED"

```

---
## Discriminated Unions mit Werten
```fsharp
// auch mit unterschiedlichen(!) Daten an jedem Fall möglich
type Shape =
    | Circle of float
    | Rectangle of float * float
let c = Circle 42.42
match c with
| Circle radius -> radius * radius * System.Math.PI
| Rectangle(width, height) -> width * height
```
---
## Record Types
```fsharp
// Record Type
type ShoppingCart = {
    products: Product list
    total: float
    createdAt: System.DateTime
}

// Typ muss bei Erzeugung normalerweise nicht angegeben werden - außer wenn er nicht eindeutig ist
let shoppingCart = {
    products = []
    total = 42.42
    createdAt = System.DateTime.Now
}
```

---
## Standard: Structural Equality
```fsharp
// Structural Equality
type Thing = {content: string; id: int}
let thing1 = {content = "abc"; id = 15}
let thing2 = {content = "abc"; id = 15}
let equal = (thing1 = thing2) // true
```

- Record Types mit Structural Equality sind ideal, um sehr kompakt "Value Objects" ausdrücken zu können
---

## Structural Equality vs. DDD Aggregates
- Möchte man die Standard-Equality nicht, ist es best practice, Equality und Comparison zu verbieten
- dann muss explizit auf eine Eigenschaft verglichen werden (z.B. die Id)

```fsharp
[<NoEquality; NoComparison>]
type NonEquatableNonComparable = {
    Id: int
}
```

---

