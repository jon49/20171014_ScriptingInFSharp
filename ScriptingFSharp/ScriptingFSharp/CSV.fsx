// If you use Paket as a package manager you can avoid the version number and
// not break your scripts when doing an update.
//
// You can also use VS Code with Ionide plugin. This has nice integration with
// Paket. If all you are doing is scripting this might be the direction you
// want to go. I just really like my full version of Visual Studio :-)
//
// Can also dynamically load these files by right clicking on reference and
// "Send to F# Interactive"
#I @"..\packages\FSharp.Data.2.3.3\lib\net40"
#r "FSharp.Data.dll"

open FSharp.Data

let source = __SOURCE_DIRECTORY__

type Cities = CsvProvider<"../../Files/cities.csv", Separators = ",">

let cities =
    Cities.GetSample ()
    |> fun x ->
        x.Rows

do
    cities
    |> Seq.head
    |> fun x -> x.City
    |> printfn "First city listed: %s"

//    let latMin = 41
//    let latMax = 42
//    printfn "Cities between latitude `%i` and `%i` inclusive." latMin latMax
//    cities
//    |> Seq.filter (fun x -> latMin <= x.LatD && x.LatD <= latMax)
//    |> Seq.map (fun x -> x.City)
//    |> Seq.iteri (fun i x -> printfn "%i. %s" (i + 1) x)
