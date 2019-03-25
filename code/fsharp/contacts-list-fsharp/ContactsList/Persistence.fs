module Persistence

open System
open System.IO
open Contact
open ContactDto

let createEmptyFileIfNoFileIsPresent writeFile isFilePresent filePath =
    if isFilePresent filePath then
        ()
    else
        let emptyJsonArray = "[]"
        writeFile filePath emptyJsonArray

let changeFileContent readFile writeFile isFilePresent filePath (changeFn : ContactDto list -> ContactDto list) =
    try
    createEmptyFileIfNoFileIsPresent writeFile isFilePresent filePath

    readFile
    |> Newtonsoft.Json.JsonConvert.DeserializeObject<ContactDto list>
    |> changeFn
    |> Newtonsoft.Json.JsonConvert.SerializeObject
    |> writeFile filePath
    |> Ok
    with
    | :? Exception as ex -> Error [ ex.Message ]

let add readFile writeFile isFilePresent filePath (contact : Contact) : Result<unit, string list> =
    let addNewContactToList = ((@) [ ContactDto.fromDomain contact ])
    changeFileContent readFile writeFile isFilePresent filePath addNewContactToList

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

let isFilePresent filePath =
    File.Exists filePath
