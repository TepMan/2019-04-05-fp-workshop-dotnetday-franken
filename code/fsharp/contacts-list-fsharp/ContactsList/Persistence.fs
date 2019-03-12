module Persistence

open System
open System.IO
open Contact

let add readFile writeFile filePath (contact : Contact) : Result<unit, string list> =
    try
    readFile
    |> Newtonsoft.Json.JsonConvert.DeserializeObject<Contact list>
    |> (@) [ contact ]
    |> Newtonsoft.Json.JsonConvert.SerializeObject
    |> writeFile filePath
    |> Ok
    with
    | :? Exception as ex -> Error [ ex.Message ]

let getFilePath basePath =
    Path.Combine [| basePath; "addressbook.json" |]

let getBasePath() =
    Directory.GetCurrentDirectory()

let getPath =
    getBasePath >> getFilePath

let writeToFile path contents =
    File.WriteAllText(path, contents)

let readFromFile path =
    File.ReadAllText path
