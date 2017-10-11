// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open IfInteractive

[<EntryPoint>]
let main argv = 
//    printfn "%A" argv
    printfn "%s" msg
    System.Console.ReadLine () |> ignore
    0 // return an integer exit code
