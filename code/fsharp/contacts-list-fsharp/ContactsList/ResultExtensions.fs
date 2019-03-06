module Result

let map2 f a b =
    match a, b with
    | Ok a, Ok b -> Ok (f a b)
    | Error a, Error b -> Error [a; b]
    | Error a, _ -> Error [a]
    | _, Error b -> Error [b]  

let apply (f: Result<('a -> 'b), 'c>) (a: Result<'a, 'c>) : Result<'b, 'c list> =
    match f, a with
    | Ok f, Ok a -> Ok (f a)
    | Error f, Error a -> Error [f; a]  
    | Error f, _ -> Error [f]  
    | _, Error a -> Error [a]  

let flatMap f x =
    match x with
    | Ok x -> f x
    | Error e -> Error e

let lift a =
    Ok a
