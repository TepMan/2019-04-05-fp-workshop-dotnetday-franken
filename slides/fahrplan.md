1) Begrüßung
2) Vorstellung wir
3) Inhalte/Lernziele Workshop
4) Vorstellungsrunde Teilnehmer
5) Erwartungen Teilnehmer
6) Was ist Mob-Programming?
7) Vorstellung Aufgabenstellung/Domäne
8) Naive Implementierung des Datenmodells für einen Kontakt (string, DateTime?, int)
9) Fokus auf Geburtsdatum

    - DateTime? ganz gut, weil schon "da oder nicht drin steckt", aber wäre es nicht schöner, ohne ständige Null-Checks und auch für Domänenexperten verständlich ausdrücken zu können?

1) Vorstellung von Option

    Semantik für "vorhanden oder nicht"

1) Einführung Discriminated Unions
2) LaYumba vorstellen
3) Wie erzeuge ich mir eine Option von DateTime?
4) PO will schnell neue Funktion haben: Das Datum muss als String ausgebbar sein, egal ob es da ist oder nicht
5) Funktion schreiben: DateTime option -> string (String.Empty falls None)
6) Pattern Matching mit LaYumba einführen
7) Neue Anforderung: Das Datum darf nur eine Datumskomponente enthalten, keine Zeitkomponente
8) Problem: Wir haben keine Funktion zur Verfügung, die mit Option<DateTime> umgehen kann
9) Einführung Mappable (Funktor)
10) Funktion implementieren und mit map verbinden
11) Nächster Fokus: Vorname
12) Vorname darf nicht leer sein - string sagt darüber aber nichts aus
13) ValueObject to the rescue
14) \<Insert Value Object Knowledge von Patrick\>
15) ValueObject erstmal mit Konstruktor und Exception, wenn was schief geht
16) Umbau Datenmodell auf NonEmptyStrings für Vorname und Nachname
17) Schwenk auf F#, damit man da auch mal was von sieht
18) Vorstellung Grundlegende Syntax
19) Record Types
20) Unterschied Default Equality Record Type vs. Value Object
21) Datenmodell in F# modellieren
22) option schon eingebaut
23) Aufhören vor dem NonEmptyString - den machen wir erst, wenn wir Results haben
24) ???