// Time by itself toggles on/off
// If you need more powerful profiling consider using PrivateEye
// http://www.privateeye.io/
#time "on"

[| 1 .. 10000000 |] |> Array.map (fun x -> x * x)

#time "off"
