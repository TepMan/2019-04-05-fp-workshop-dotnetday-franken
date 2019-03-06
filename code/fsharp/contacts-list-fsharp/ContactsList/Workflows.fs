module Workflows

let add guid firstName lastName twitterProfileUrl dateOfBirth primaryContactMethod iq =
    () // TODO

let delete guid =
    () // TODO

let prepareOutput filterPredicate format makePrintable contacts =
    contacts
    |> List.filter filterPredicate
    |> List.map format
    |> List.reduce makePrintable
