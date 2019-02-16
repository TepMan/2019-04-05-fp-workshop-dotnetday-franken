module EMailAddressTests

open EmailAddress
open Xunit
open FsUnit.Xunit

[<Fact>]
let ``valid Mail is Ok`` () =
    let mail = "abc@def.de"
    create mail |> Result.isOkAndEquals EmailAddress.get mail |> should equal true

[<Fact>]
let ``empty string becomes Error`` () =
    create "" |> Result.isError |> should equal true    


[<Fact>]
let ``null string becomes Error`` () =
    create null |> Result.isError |> should equal true


[<Fact>]
let ``invalid string becomes Error`` () =
    create "a..d" |> Result.isError |> should equal true