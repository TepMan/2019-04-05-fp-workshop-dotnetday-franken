module Domain

open System
open NonEmptyString
open EmailAddress

type ContactMethod =
    | Email of EmailAddress
    //| Snailmail of PostalAddress 
    //| Phone of PhoneNumber


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
