module Contact

open System
open NonEmptyString
open PositiveNumber
open Domain

[<NoEquality; NoComparison>]
type Contact = {
    Id : Guid
    FirstName : NonEmptyString
    LastName : NonEmptyString
    TwitterProfileUrl : NonEmptyString option
    DateOfBirth : DateTime option
    PrimaryContactMethod : ContactMethod
    Iq : PositiveNumber
}

let create id firstName lastName twitterProfileUrl dateOfBirth primaryContactMethod iq =
    {
        Contact.Id = id
        FirstName = firstName
        LastName = lastName
        TwitterProfileUrl = twitterProfileUrl
        DateOfBirth = dateOfBirth
        PrimaryContactMethod = primaryContactMethod
        Iq = iq
    }