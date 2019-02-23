module Domain

open System
open NonEmptyString
open EmailAddress
open PostalAddress

type ContactMethod =
    | Email of EmailAddress
    | Snailmail of PostalAddress 


[<NoEquality; NoComparison>]
type Contact = {
    Id : Guid
    FirstName : NonEmptyString
    LastName : NonEmptyString
    TwitterProfileUrl : NonEmptyString option
    DateOfBirth : DateTime option
    PrimaryContactMethod : ContactMethod
    OtherContactMethods : ContactMethod list
}

let add firstName lastName twitterProfileUrl dateOfBirth primaryContactMethod otherContactMethods =
    () // TODO

let delete id =
    () // TODO

let output () =
    () // TODO