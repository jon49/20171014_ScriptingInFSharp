// Not your grandfather's ORM
// http://fsprojects.github.io/FSharp.Data.SqlClient/
#I @"..\packages\FSharp.Data.SqlClient.1.8.2\lib\net40"
#r "FSharp.Data.SqlClient.dll"

open FSharp.Data

// C# Constant
// Using sakila database
// https://www.jooq.org/sakila
[<Literal>]
let ConnectionString =
    @"Data Source=.;Initial Catalog=sakila;Integrated Security=True"

type Sakila = SqlProgrammabilityProvider<ConnectionString>

do
    use getActor = new Sakila.dbo.GetActorInfo(ConnectionString)
    let actorInfo = getActor.ExecuteSingle(2)
    actorInfo
    |> Option.iter (fun x ->
        printfn "%s %s - %A" x.first_name x.last_name x.last_update
    )

    use getActorInfo = new SqlCommandProvider<"
        SELECT first_name, last_name, title
        FROM actor a
        JOIN film_actor fa
            ON a.actor_id = fa.actor_id
        JOIN film f
            ON f.film_id = fa.film_id
        WHERE a.actor_id = @ActorID
        ", ConnectionString>(ConnectionString)

    getActorInfo.AsyncExecute(1)
    |> Async.RunSynchronously
    |> Seq.iter ( fun x -> printfn "%s %s - %s" x.first_name x.last_name x.title)

    use getMovie = new SqlCommandProvider<"./GetFilm.sql", ConnectionString>(ConnectionString)
    getMovie.Execute(1)
    |> Seq.iter ( fun x -> printfn "%s: %A" x.title x.description )

    // Also does ENUMs!

