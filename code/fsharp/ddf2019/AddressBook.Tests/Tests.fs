module Tests

open System
open Xunit
open FsUnit
open FsUnit.Xunit

[<Fact>]
let ``Smoketest for FsUnit``() = true |> should equal true
// [<Fact>]
// let f() = fail
