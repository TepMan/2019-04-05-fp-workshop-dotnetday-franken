module WorkflowsTests

open Domain
open Xunit
open FsUnit.Xunit
open PositiveNumber
open Result
open Contact

[<Fact>]
let ``prepareOutput function works``() =
    // Idee: create mit der Guid angewendet via Lift in ein Result, alles andere auch liften was kein Result ist,
    // und dann mit apply alles verbinden.
    // Dann kommt am Ende entweder ein Contact raus, oder eine Liste mit Errors, was nicht geklappt hat
    let homer =
        (lift
             (Contact.create
              <| System.Guid.Parse("bba52030-19ce-4c02-b1dd-792b0120855b")))
        <*> (NonEmptyString.create "Homer")
        <*> (NonEmptyString.create "Simpson") <*> (lift None) <*> (lift None)
        <*> (Result.map Email
                 (Result.bind EmailAddress.create
                      (NonEmptyString.create "a@b.c")))
        <*> (PositiveNumber.create 50)

    let lisa =
        (lift
             (Contact.create
              <| System.Guid.Parse("9af01860-8bb0-4e54-a6bb-2c7614fef928")))
        <*> (NonEmptyString.create "Lisa") <*> (NonEmptyString.create "Simpson")
        <*> (lift None) <*> (lift None)
        <*> (Result.map Email
                 (Result.bind EmailAddress.create
                      (NonEmptyString.create "a@b.c")))
        <*> (PositiveNumber.create 120)

    let bart =
        (lift
             (Contact.create
              <| System.Guid.Parse("bba52030-19ce-4c02-b1dd-792b0120855b")))
        <*> (NonEmptyString.create "Bart") <*> (NonEmptyString.create "Simpson")
        <*> (lift None) <*> (lift None)
        <*> (Result.map Email
                 (Result.bind EmailAddress.create
                      (NonEmptyString.create "a@b.c")))
        <*> (PositiveNumber.create 90)

    match homer, lisa, bart with
    | Ok h, Ok l, Ok b ->
        [ h; l; b ]
        |> (Workflows.prepareOutput (Filters.byIq 60) Formatters.firstNameOnly
                Printer.reduceToSingleString)
        |> NonEmptyString.get
        |> (should equal "Lisa,Bart")
    | _, _, _ -> true |> should equal false
