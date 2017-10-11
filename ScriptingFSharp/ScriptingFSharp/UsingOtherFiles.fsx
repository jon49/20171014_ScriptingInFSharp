// If you change the file Person.fs you may need to reopen the fsx file that
// uses it.
// If Person.fs had other dependencies you would need to reference those above
// also.
#load "Person.fs"

module Person = ScriptingFSharp.Person

open System

let george = {
    Person.FirstName = "George"
    Person.LastName = "Orwell"
    Person.BirthDate = DateTime(2000, 1, 2)
}

#load "add.fsx"
open Math

let two = add 1 1

// Without module name
// Note casing on `open` statement

#load "add2.fsx"
open Add2
let three = add2 1
