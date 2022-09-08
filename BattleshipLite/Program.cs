using BattleshipLite;
using BattleshipLiteLibrary;
using BattleshipLiteLibrary.Models;
using CommonLibrary;

var gameLogic = new GameLogic();
PlayerFleetModel winner = null;
ConsoleHelper.Display("***First Player***");
var firstPlayer = new PlayerFleetModel
{
    FirstName = ConsoleHelper.RequestInput("Please enter First Name: "),
    LastName = ConsoleHelper.RequestInput("Please enter Last Name: ")
};

GameLogic.InitialisePlayerFleet(firstPlayer);

GameLogic.RecordPlayerShipLocations(firstPlayer);

Console.Clear();
ConsoleHelper.Display("***Second Player***");
var secondPlayer = new PlayerFleetModel
{
    FirstName = ConsoleHelper.RequestInput("Please enter First Name: "),
    LastName = ConsoleHelper.RequestInput("Please enter Last Name: ")
};

GameLogic.InitialisePlayerFleet(secondPlayer);

GameLogic.RecordPlayerShipLocations(secondPlayer);

(PlayerFleetModel player, PlayerFleetModel opponent) = (firstPlayer, secondPlayer);

do
{
    gameLogic.DisplayPlayerShotGrid(player);
    bool isAHit = gameLogic.RequestForShot(player, opponent);
    if (isAHit)
    {
        ConsoleHelper.Display("Your shot sunk a opponent's ship");
        Console.ReadLine();
    }
    else
    {
        ConsoleHelper.Display("Your shot was a miss.");
        Console.ReadLine();
    }
    bool isWinnerAvailable = gameLogic.WinnerCheck(opponent);
    if (isWinnerAvailable)
    {
        winner = player;
    }
    else
    {
        Console.Clear();
        (opponent, player) = (player, opponent);
    }
} while (winner == null);

ConsoleHelper.Display($"{player.FullName} is the game winner!!!");
ConsoleHelper.Display($"{player.FullName} took {player.Shots.Where(s => s.Status != GridLocationStatus.None).Count()} shots to winn the game");

Console.ReadLine();