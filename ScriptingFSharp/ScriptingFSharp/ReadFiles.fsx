open System.IO

let source = __SOURCE_DIRECTORY__

// https://people.sc.fsu.edu/~jburkardt/data/csv/csv.html
let cities = File.ReadAllLines <| Path.Combine (source, "../../Files/cities.csv")

let citiesHeader =
    cities |> Array.head

let citiesData =
    cities |> Array.tail

do
    cities
    |> Array.head
    |> printfn "%s"


