module FsUnit

open FsUnit.Xunit

let fail = true |> should equal false
