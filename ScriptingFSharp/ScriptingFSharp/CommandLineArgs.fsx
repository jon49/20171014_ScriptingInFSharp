// http://www.markhneedham.com/blog/2009/07/16/f-passing-command-line-arguments-to-a-script/
// for when you are creating console apps a great command line arguments parser
// https://github.com/fsprojects/Argu
open System

let argv = Environment.GetCommandLineArgs () |> Array.toList

//let argv = [ "hello"; "--"; "my"; "arg"; "list" ]

let rec GetArgs = function
    | "--" :: rest -> rest
    | _ :: tail -> GetArgs tail
    | [] -> List.empty

let args = GetArgs argv

printfn "%A" args
