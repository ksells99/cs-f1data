C# console app that fetches the Formula 1 calendar, drivers and constructors standings from the Ergast API (http://ergast.com/mrd/) and outputs them to the console and a text file.

When running the app you can specify whether you only want to fetch the calendar, drivers standings or constructors standings by adding an argument at the end of the command:

`dotnet run calendar`
![Calendar]("showcase-calendar.png")

`dotnet run drivers`
![DriversStandings]("showcase-drivers.png")

`dotnet run constructors`
![ConstructorsStandings]("showcase-constructors.png")

Alternatively you can fetch all data at once via either `dotnet run` or `dotnet run all`.
