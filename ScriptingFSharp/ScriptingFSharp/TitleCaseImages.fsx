// http://theburningmonk.com/2011/10/use-fsharp-to-meet-your-scripting-needs/
open System.IO
open System.Threading

let rec filesUnder basePath =
    seq {
        yield! Directory.GetFiles(basePath)
        for subDir in Directory.GetDirectories(basePath) do
            yield! filesUnder subDir
    }

let toTitleCase (str : string) =
    Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase <| str.ToLower()

let (|FileExtension|) filePath = Path.GetExtension(filePath).ToLower()

let (|IsImageFile|_|) filePath = 
    match filePath with
    | FileExtension ".jpg" 
    | FileExtension ".png" 
    | FileExtension ".gift" 
        -> Some()
    | _ -> None

//let userDir = System.Environment.GetFolderPath (System.Environment.SpecialFolder.UserProfile)
//printfn "%s" <| userDir

let imageFiles = 
    Path.Combine(System.Environment.GetFolderPath (System.Environment.SpecialFolder.UserProfile), "Downloads/test")
    |> filesUnder
    |> Seq.filter (fun filePath -> match filePath with | IsImageFile -> true | _ -> false)

printfn "Before renaming:"
imageFiles |> Seq.iter (printfn "%s")

printfn "Press any key to rename these files..."
System.Console.Read()

// rename files
imageFiles
|> Seq.iter(fun filePath ->     
    let fileName = Path.GetFileName(filePath)
    File.Move(filePath, sprintf "%s\%s" (Path.GetDirectoryName filePath) (toTitleCase fileName)))

printfn "After renaming:"
imageFiles |> Seq.iter (printfn "%s")
