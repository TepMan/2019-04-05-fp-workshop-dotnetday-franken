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
    - Semantik für "vorhanden oder nicht"
    - Code-Beispiel vorbereiten

2) PD: LaYumba vorstellen
3) Wie erzeuge ich mir eine Option von DateTime?
4) PO will schnell neue Funktion haben: Das Datum muss als String ausgebbar sein, egal ob es da ist oder nicht
5) Funktion schreiben: DateTime option -> string (String.Empty falls None)
6) PD: Pattern Matching mit LaYumba einführen
   - Code-Beispiel vorbereiten

7) Neue Anforderung: Das Datum darf nur eine Datumskomponente enthalten, keine Zeitkomponente
8) Problem: Wir haben keine Funktion zur Verfügung, die mit Option<DateTime> umgehen kann
9)  Einführung Mappable (Funktor)
10) Funktion implementieren und mit map verbinden
11) Nächster Fokus: Vorname
12) Vorname darf nicht leer sein - string sagt darüber aber nichts aus
13) PD: ValueObject to the rescue
14) PD: \<Insert Value Object Knowledge von Patrick\>
15) PD: ValueObject erstmal mit Konstruktor und Exception, wenn was schief geht
16) Umbau Datenmodell auf NonEmptyStrings für Vorname und Nachname
17) Schwenk auf F#, damit man da auch mal was von sieht
18) Vorstellung Grundlegende Syntax (let, Expressions, |>, Pattern Matching)
19) Record Types
20) Unterschiede und Gemeinsamkeiten Record Type vs. Value Object
21) Partial Application / Currying
22) Bisheriges Datenmodell in F# modellieren
23) Funktionen für DateTime option -> string und für map auch implementieren 
    1)  option schon eingebaut
24) Nächste Anforderung: Ein Kontakt kann gespeichert werden, und nach erfolgreichem Speichern wird eine Benachrichtigung verschickt
25) Speichern kann fehlschlagen: Wie drücken wir aus, dass es klappen oder fehlschlagen kann?
26) Ergebnis ist entweder ein Erfolg oder ein Fehlschlag -> Result
27) Result (Either) vorstellen
28) Monade einführen
29) Beispiel mit String Validierung ausprogrammieren
30) PD: Railway Oriented Programming vorstellen
31) Ausprogrammieren: Kontakt kann gespeichert werden, und nach erfolgreichem Speichern wird eine Benachrichtigung verschickt
32) Rückgabe für den User notwendig: Funktion, die auf Result am Ende der Kette pattern matching macht und jeweils Strings ausgibt
33) Intermezzo: Funktionale Architektur(en)
34) Datenmodell in F# erweitern auf Kontaktmethode
35) Einführung Discriminated Unions
36) PD: Wie kann man das in C# nachbilden? Nicht ohne zusätzliche Bibliothek
37) Neue Anforderung: Fehler beim Erzeugen eines Kontakts (Validierung) sollen gesammelt werden, nicht beim Ersten abgebrochen wie beim Speichern
38) Applicative einführen
39) Ausprogrammieren: Fehler beim Erzeugen eines Kontakts (Validierung) sollen gesammelt werden, nicht beim Ersten abgebrochen wie beim Speichern
40) Exkurs: How to introduce F# into YOUR project
41) Zusammenfassung des Gelernten
42) Falls noch Zeit ist: Einfach am Projekt weiterprogrammieren und die Konzepte anwenden/vertiefen
43) Feedbackrunde