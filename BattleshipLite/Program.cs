using BattleshipLite;
using BattleshipLiteLibrary;
using BattleshipLiteLibrary.Models;

var gameLogic = new GameLogic();
Console.WriteLine("***First Player***");
var firstPlayer = new PlayerFleetModel
{
    FirstName = ConsoleMessage.UserInput("Please enter First Name: "),
    LastName = ConsoleMessage.UserInput("Please enter Last Name: ")
};

GameLogic.InitialisePlayerFleet(firstPlayer);

GameLogic.RecordPlayerShipLocations(firstPlayer);

Console.Clear();
Console.WriteLine("***Second Player***");
var secondPlayer = new PlayerFleetModel
{
    FirstName = ConsoleMessage.UserInput("Please enter First Name: "),
    LastName = ConsoleMessage.UserInput("Please enter Last Name: ")
};

GameLogic.InitialisePlayerFleet(secondPlayer);

GameLogic.RecordPlayerShipLocations(secondPlayer);

Console.ReadLine();