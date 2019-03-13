---
title: Von C# nach F#...
theme: sky
revealOptions:
    transition: 'fade'
    controls: false
    progress: false
    autoPlayMedia: true
    transitionSpeed: slow

---
<!-- .slide: data-background="images/road-3478977_1920.jpg" -->

<h2 style="position: absolute; top: 390px; right: -150px; color: #ccc; text-transform: none;">Funktionale Programmierung</h2>

<p style="position: absolute; top: 470px; right: -145px; color: #ccc; text-transform: none; text-align: right" class="my-shadow">@mobilgroma</p>
<p style="position: absolute; top: 520px; right: -145px; color: #ccc; text-transform: none; text-align: right" class="my-shadow">@drechsler<br/>Redheads Ltd.</p>

Note:
Diese Notizen erscheinen nur als Speaker Notes (optional)

---

<img src="images/drechsler-profile.jpg" class="borderless" style="position: relative; top: 10px; left: -400px; height: 250px">

<div style="position: absolute; top: 100px; left: 200px; height: 1000px; width: 800px;">
  <h4>Patrick Drechsler</h4>
  <ul class="small-font" >
    <li>Software Entwickler / Architekt</li>
    <li>Beruflich: C# (und TS/JS)</li>
    <li>Interessen:</li>
    <ul>
      <li>Software Crafting</li>
      <li>Domain-Driven-Design</li>
      <li>Funktionale Programmierung</li>
    </ul>
    
    <li>...</li>
  </ul>
</div>

<div style="position: absolute; top: 500px; left: 600px">
  <img src="images/redheads-logo.png" class="borderless" style="height: 80px;">
</div>

<div style="position: absolute; top: 520px; left: -100px" class="small-font">
  <i class="fa fa-twitter" aria-hidden="true"></i> @drechsler
  <i class="fa fa-github" aria-hidden="true"></i> draptik
  <!-- <img src="images/redheads-logo.png" class="borderless" style="height: 80px;"> -->
</div>

---

<img src="images/grotz-profile.jpg" class="borderless" style="position: relative; top: 10px; left: -400px; height: 250px">

<div style="position: absolute; top: 100px; left: 200px; height: 1000px; width: 800px;">
  <h4>Martin Grotz</h4>
  <ul class="small-font" >
    <li>Software Entwickler</li>
    <li>Interessen:</li>
    <ul>
      <li>Software Crafting</li>
      <li>Domain-Driven-Design</li>
      <li>Funktionale Programmierung</li>
    </ul>
    
    <li>...</li>
  </ul>
</div>

<div style="position: absolute; top: 500px; left: 400px">
  <img src="images/redheads-logo.png" class="borderless" style="height: 100px;">
</div>

---

## Vorstellungsrunde
## &
## Erwartungen

---

## Mob Programming

- wir lernen gemeinsam
- Pair Programming in der Gruppe


----

<img src="images/mob-programming-setup.png" class="borderless" style="height: 50%;">

----

- Driver: Sitzt an der Tastatur (darf nicht denken)
- Navigator: Sagt dem Driver, was zu tun ist
- Mob: Unterstuetzt den Navigator
- Regelmaessiger Wechsel (3-5min)

----

### "Assisted" Mob Programming

- Facilitator unterstuetzt den Navigator

---

## FP History

- 1920: Lambda Calculus
- 1950: LISP
- 1970: Scheme (OO & FP)
- ...
- XXXX: Haskell
- XXXX: Scala
- XXXX: F#
- XXXX: ...

---

## FP Overview

Typed vs Untyped FP

---

## FP 101

- Immutability
- Functions as First Class Citizens
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

----

```csharp
// method signature lies!
int Add(int a, int b)
{
  Console.WriteLine("foo"); // <- side effect!
  return a + b;
}
```

----

```csharp
int Add(int a, int b)
{
  Console.WriteLine("foo");
  return a + b;
}
```

```csharp
int Add(int a, int b)
{
  return a + b;
}
```

Expression body syntax:
```csharp
int Add(int a, int b) => a + b;
```

---

Und was hat es mit

Filter

Map

Reduce

auf sich?

---

Schränken uns diese FP Paradigmen ein?

---

Wie kann man mit diesem "Purismus" Software schreiben, die etwas tut?

---

# Let's code

(almost)

---

One more thing: Die Fachlichkeit

(laesstiges Detail...)

---

### Kontakt-App

---

### Kontakt-App

Einträge 
- Hinzufügen
- Auflisten
- Löschen 

----

- Eintrag
  - Vorname
  - Nachname
  - Kontaktmethode
  - optionale Felder
    - Geburtstag
    - Twitter-Link
    - weitere Kontaktmethoden 

----

- Eintrag wird serialisiert und in Datei abgelegt
- APIs: Kommandozeile, Datei

---

Und warum hat C# andere Verben verwendet?

- Als C# LINQ eingefuehrt hat, war FP nicht hipp
- SQL ist funktional

-> Syntax

---

## LINQ - fuer Listen (IEnumerable in C#)

Allg.: Funktionen, die auf eine Liste angewendet werden

Bsp:

- Option ist eigentlich nur eine Liste mit 2 Werten (Some und None)
- Result -> Liste mit 2 Werten (Left und Right)
- etc.

In FP unterscheidet man die Wrapper-Klassen (zB IEnumerable) anhand der Funktionen, die sie bereitstellen

---

## FP-Jargon: Verschiedene Arten von Funktionen, die angewendet werden

- Functor: Funktion auf jedes Element anwenden (Map)
- Monad: ...
- Applicative: ...

