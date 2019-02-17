module EmailAddress

open System

type EmailAddress = private EmailAddress of string

let create s =
    if String.IsNullOrWhiteSpace s then
        Error "Address must not be empty"
    else
        try
            System.Net.Mail.MailAddress(s, null) |> ignore
            Ok <| EmailAddress s

        with
            | :? System.FormatException as ex -> Error "Invalid format"
            | _ -> Error "Other unexpected error"

let get (EmailAddress ea) = 
    ea