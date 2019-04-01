module Persistence

open System
open System.IO
open Contact
open ContactDto
open Result

let createEmptyFileIfNoFileIsPresent writeFile isFilePresent filePath =
    if isFilePresent filePath then ()
    else
        let emptyJsonArray = "[]"
        writeFile filePath emptyJsonArray

let changeFileContent readFile writeFile isFilePresent filePath
    (changeFn : ContactDto list -> Result<ContactDto list, string list>) =

    try
        createEmptyFileIfNoFileIsPresent writeFile isFilePresent filePath
        readFile
        |> Newtonsoft.Json.JsonConvert.DeserializeObject<ContactDto list>
        |> changeFn
        |> Result.map Newtonsoft.Json.JsonConvert.SerializeObject
        |> Result.map (writeFile filePath)
    with
    ex -> Error [ ex.Message ]

let addNewContactToList (contact : Result<Contact, 'a>) : ContactDto list -> Result<ContactDto list, 'a>
        =
        let conc (newEle : Result<ContactDto, 'b list>) oldList =
                match newEle with
                | Ok e -> (e :: oldList) |> Ok
                | Error err -> Error err

        Result.map ContactDto.fromDomain contact
        |> conc
        // >>= (Ok ((@) []))
        // = Result.map (ContactDto.fromDomain) contact
        // |> Result.map (fun c -> ((@) [ c ]))

let add readFile writeFile isFilePresent filePath (contact : Contact) : Result<unit, string list> =
    let ac = (addNewContactToList (Ok contact))

    changeFileContent readFile writeFile isFilePresent filePath ac


let edit readFile writeFile isFilePresent filePath oldContactId (changedContact : Contact) : Result<Contact, string list> =
    let editContact changed oldContacts =
        let failIfNotFound filteredContacts =
                if List.length filteredContacts = List.length oldContacts then
                        Error "Contact to edit not found"
                else
                        Ok filteredContacts
        let compareById (c : ContactDto) =
                c.id = oldContactId
        List.filter compareById oldContacts
        |> failIfNotFound
        |> Result.map (List.except oldContacts)
        |> Result.map (addNewContactToList changed)

    changeFileContent readFile writeFile isFilePresent filePath
        ((editContact changedContact))
        |> Result.map (fun _ -> changedContact)



let getFilePath basePath = Path.Combine [| basePath; "addressbook.json" |]
let getBasePath() = Directory.GetCurrentDirectory()
let getPath = getBasePath >> getFilePath
let writeToFile path contents = File.WriteAllText(path, contents)
let readFromFile path = File.ReadAllText path
let isFilePresent filePath = File.Exists filePath
