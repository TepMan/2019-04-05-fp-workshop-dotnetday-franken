module AddressData

open NonEmptyString
open GermanZipCode

type AddressData = {
    street : NonEmptyString
    zip : GermanZipCode
    city: NonEmptyString
}
