1) Begrüßung
2) Vorstellung wir
4) Vorstellungsrunde Teilnehmer
5) Erwartungen Teilnehmer
3) Inhalte/Lernziele Workshop
6) Was ist Mob-Programming?
7) Vorstellung Aufgabenstellung/Domäne
8) Naive Implementierung des Datenmodells für einen Kontakt (string, DateTime?, int)
9)  Fokus auf Geburtsdatum

    - DateTime? ganz gut, weil schon "da oder nicht drin steckt", aber wäre es nicht schöner, ohne ständige Null-Checks und auch für Domänenexperten verständlich ausdrücken zu können?

10) Vorstellung von Option
    - Semantik für "vorhanden oder nicht"
    - Code-Beispiel vorbereiten

11) PD: LaYumba vorstellen
12) Wie erzeuge ich mir eine Option von DateTime?
13) MG: PO will schnell neue Funktion haben: Das Datum muss als String ausgebbar sein, egal ob es da ist oder nicht
14) Funktion schreiben: DateTime option -> string (String.Empty falls None)
15) PD: Pattern Matching mit LaYumba einführen
   - Code-Beispiel vorbereiten

17) MG: Neue Anforderung: Das Datum darf nur eine Datumskomponente enthalten, keine Zeitkomponente
18) Problem: Wir haben keine Funktion zur Verfügung, die mit Option<DateTime> umgehen kann
19) MG: Einführung Mappable (Funktor)
20) Funktion implementieren und mit map verbinden
21) Nächster Fokus: Vorname
22) Vorname darf nicht leer sein - string sagt darüber aber nichts aus
23) PD: ValueObject to the rescue
24) PD: \<Insert Value Object Knowledge von Patrick\>
25) PD: ValueObject erstmal mit Konstruktor und Exception, wenn was schief geht
26) Umbau Datenmodell auf NonEmptyStrings für Vorname und Nachname
27) Schwenk auf F#, damit man da auch mal was von sieht
28) MG: Vorstellung Grundlegende Syntax (let, Expressions, |>, Pattern Matching)
29) MG: Record Types
30) MG: Unterschiede und Gemeinsamkeiten Record Type vs. Value Object
31) MG: Partial Application / Currying
32) MG: Bisheriges Datenmodell in F# modellieren
33) MG: Funktionen für DateTime option -> string und für map auch implementieren 
    1)  option schon eingebaut
34) MG: Nächste Anforderung: Ein Kontakt kann gespeichert werden, und nach erfolgreichem Speichern wird eine Benachrichtigung verschickt
35) Speichern kann fehlschlagen: Wie drücken wir aus, dass es klappen oder fehlschlagen kann?
36) Ergebnis ist entweder ein Erfolg oder ein Fehlschlag -> Result
37) Result (Either) vorstellen
38) Monade einführen
39) Beispiel mit String Validierung ausprogrammieren
40) PD: Railway Oriented Programming vorstellen
41) Ausprogrammieren: Kontakt kann gespeichert werden, und nach erfolgreichem Speichern wird eine Benachrichtigung verschickt
42) MG: Neue Anforderung: Rückgabe für den User notwendig: Funktion, die auf Result am Ende der Kette pattern matching macht und jeweils Strings ausgibt
43) MG: Intermezzo: Funktionale Architektur(en)
44) MG: Datenmodell in F# erweitern auf Kontaktmethode
45) MG: Wiederholung Discriminated Unions (eingeführt schon im F# Basics Teil)
46) PD: Wie kann man das in C# nachbilden? Nicht ohne zusätzliche Bibliothek
47) MG: Neue Anforderung: Fehler beim Erzeugen eines Kontakts (Validierung) sollen gesammelt werden, nicht beim Ersten abgebrochen wie beim Speichern
48) Applicative einführen
49) Ausprogrammieren: Fehler beim Erzeugen eines Kontakts (Validierung) sollen gesammelt werden, nicht beim Ersten abgebrochen wie beim Speichern
50) MG: Exkurs: How to introduce F# into YOUR project
51) Zusammenfassung des Gelernten
52) Falls noch Zeit ist: Einfach am Projekt weiterprogrammieren und die Konzepte anwenden/vertiefen
53) Feedbackrunde
54) Verabschiedung