module Result
   
let isOkAndEquals getFn compareTo result =
    match result with
    | Error _ -> false
    | Ok v -> getFn v = compareTo

let isError result =
    match result with
    | Error _ -> true
    | Ok _ -> false