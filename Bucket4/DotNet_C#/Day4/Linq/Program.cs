using Linq;

var games = new List<Games>
{
    new Games { Title = "The Legend of Zelda: Breath of the Wild", Genre = "Action-adventure", ReleaseYear = 2017, Rating = 9.5, Price = 59 },
    new Games { Title = "God of War", Genre = "Action-adventure", ReleaseYear = 2018, Rating = 9.3, Price = 49 },
    new Games { Title = "Red Dead Redemption 2", Genre = "Action-adventure", ReleaseYear = 2018, Rating = 9.7, Price = 69 },
    new Games { Title = "The Witcher 3: Wild Hunt", Genre = "RPG", ReleaseYear = 2015, Rating = 9.4, Price = 39 },
    new Games { Title = "Minecraft", Genre = "Sandbox", ReleaseYear = 2011, Rating = 9.0, Price = 26 },
    new Games { Title = "Fortnite", Genre = "Battle Royale", ReleaseYear = 2017, Rating = 8.5, Price = 0 },
    new Games { Title = "Among Us", Genre = "Party", ReleaseYear = 2018, Rating = 8.0, Price = 5 },
    new Games { Title = "Cyberpunk 2077", Genre = "RPG", ReleaseYear = 2020, Rating = 7.5, Price = 59 },
    new Games { Title = "Hades", Genre = "Roguelike", ReleaseYear = 2020, Rating = 9.2, Price = 24 },
    new Games { Title = "Animal Crossing: New Horizons", Genre = "Simulation", ReleaseYear = 2020, Rating = 9.1, Price = 59 }
};

/*
List<String> allGames = new List<String>();

foreach (var game in games)
{
    allGames.Add(game.Title);
}

foreach (var title in allGames)
{
    Console.WriteLine(title);
}
*/

//USING SELECT

/*
var allGames = games.Select(n => n.Title);
foreach (var title in allGames)
{
    Console.WriteLine(title);
}
*/

/*
var Genregames = games.Where(games => games.Genre == "RPG");
foreach (var item in Genregames)
{
    Console.WriteLine(item.Title);
}
*/

/*
bool modrngames = games.Any(games => games.ReleaseYear >= 2020);
Console.WriteLine(modrngames);
*/

/*
var sortbygames = games.OrderBy(games => games.ReleaseYear);
foreach (var item in sortbygames)
{
    Console.WriteLine($"{item.Title} -- {item.ReleaseYear}");
}
*/

/*
var sortbygames = games.OrderByDescending(games => games.ReleaseYear);
foreach (var item in sortbygames)
{
    Console.WriteLine($"{item.Title} -- {item.ReleaseYear}");
}
*/

//AGGREGATE FUNCTIONS

/*
var avgprice = games.Average(games => games.Price);
Console.WriteLine($"Average Games Price: {avgprice}");
*/

/*
var minValue = games.Min(games => games.Price);
Console.WriteLine($"Minimum Games Price: {minValue}");
*/

/*
var maxValue = games.Max(games => games.Price);
Console.WriteLine($"Maximum Games Price: {maxValue}");
*/

/*
var maxValue = games.Max(games => games.Rating);
var first = games.First(games => games.Rating == maxValue);
Console.WriteLine($"{first.Rating} {first.Title}");
*/

/*
var groupbyop = games.GroupBy(g => g.Genre);
foreach (var group in groupbyop)
{
    Console.WriteLine($"Genre - {group.Key}");
    foreach (var game in group)
    {
        Console.WriteLine($" -- {game.Title}");
    }
    Console.WriteLine();
}
*/

/*
var multicondition = games.Where(n => n.Genre == "RPG" && n.ReleaseYear > 2015).OrderBy(n => n.ReleaseYear).Select(n => $"{n.Title} -- {n.Price} -- {n.Rating}");
foreach (var game in multicondition)
{
    Console.WriteLine(game);
}
*/
