// Tools > Options > F# Tools > F# Interactive > Enable Script Debugging = True
// Reset Interactive Session

let (|DivisibleBy|_|) d n =
    if n % d = 0 then
        Some ()
    else
        None

{ 1 .. 100 }
|> Seq.map ( fun x ->
    match x with
    | DivisibleBy 15 -> "FizzBuzz"
    | DivisibleBy 3 -> "Fizz"
    | DivisibleBy 5 -> "Buzz"
    | x -> x.ToString() )
|> Seq.iter (printfn "%s")
