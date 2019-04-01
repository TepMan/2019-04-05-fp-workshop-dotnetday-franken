module PersistenceTests

open System
open Xunit
open FsUnit.Xunit
open TestContacts

open Persistence

[<Fact>]
let ``adding an entry to an empty 'file' adds the entry``() =
    let readFile = "[]"
    let writeFile p s =
        ()
    let isFilePresent p = true
    let filePath = "dontcare"

    let fn = Persistence.add readFile writeFile isFilePresent filePath
    match Result.map fn homer with
    | Ok _ -> true |> should equal true
    | Error _ -> false |> should equal true

[<Fact>]
let ``adding an entry to existing entries adds the entry``() =
    let mutable finalString = ""
    let readFile = """[{"id":"bba52030-19ce-4c02-b1dd-792b0120855b","firstName":"Homer","lastName":"Simpson","twitterProfileUrl":null,"dateOfBirth":null,"primaryContactMethod":{"EmailAddress":{"Case":"Some","Fields":["a@b.c"]},"PostalAddress":null},"iq":50}]"""
    let writeFile p s =
        finalString <- s
        ()
    let isFilePresent p = true
    let filePath = "dontcare"

    let fn = Persistence.add readFile writeFile isFilePresent filePath
    match Result.map fn lisa with
    | Ok _ -> (String.length finalString) |> should be (greaterThan (String.length readFile))
    | Error _ -> false |> should equal true
