using BattleshipLiteLibrary.Models;
using CommonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipLiteLibrary
{
    public class GameLogic
    {
        public static void RecordPlayerShipLocations(PlayerFleetModel firstPlayer)
        {
            do
            {
                Console.Write($"Enter ship number {firstPlayer.Ships.Count + 1} location: ");
                var userInput = Console.ReadLine();
                (string letter, int number, bool isValidInput) = ValidateGridLocation(userInput);
                if (isValidInput && IsValidLocation(letter, number, firstPlayer, true, false))
                {
                    var ship = new GridLocationModel
                    {
                        Letter = letter,
                        Number = number,
                        Status = GridLocationStatus.Ship
                    };
                    firstPlayer.Ships.Add(ship);
                }
                else
                {
                    Console.Write("That was not a valid location, ");
                }

            } while (firstPlayer.Ships.Count < 5);
        }

        private static bool IsValidLocation(string letter, int number, PlayerFleetModel firstPlayer, bool shipCheck = false, bool shotCheck = false)
        {
            bool output = true;

            if (shipCheck)
            {
                foreach (var ship in firstPlayer.Ships)
                {
                    if (ship.Letter == letter && ship.Number == number)
                    {
                        output = false;
                    }
                } 
            }
            else
            {
                foreach (var shot in firstPlayer.Shots)
                {
                    if (shot.Letter == letter && shot.Number == number && shot.Status != GridLocationStatus.None)
                    {
                        output = false;
                    }
                }
            }

            return output;
        }

        private static (string letter, int number, bool isValidInput) ValidateGridLocation(string userInput)
        {
            bool isValidInput;
            string letter = string.Empty, stringNumber = string.Empty;
            int number = default(int);

            if (string.IsNullOrEmpty(userInput) || userInput.Length > 2)
            {
                isValidInput = false;
            }
            else
            {

                letter = userInput.Substring(0, 1);
                stringNumber = userInput.Substring(1);
                if (letter.IsValidGridLetter() && stringNumber.IsValidGridNumber())
                {
                    isValidInput = true;
                    number = int.Parse(stringNumber);
                }
                else
                {
                    isValidInput = false;
                }
            }

            return (letter.ToUpper(), number, isValidInput);
        }

        public static void InitialisePlayerFleet(PlayerFleetModel player)
        {
            string[] letters = new string[] { "A", "B", "C", "D", "E" };
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    GridLocationModel gridLocation = new GridLocationModel
                    {
                        Letter = letters[i],
                        Number = numbers[j]
                    };
                    gridLocation.Status = GridLocationStatus.None;
                    player.Shots.Add(gridLocation);
                }
            }
        }

        public void DisplayPlayerShotGrid(PlayerFleetModel player)
        {
            string[] letters = new string[] { "A", "B", "C", "D", "E" };
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    var location = new GridLocationModel
                    {
                        Number = numbers[i],
                        Letter = letters[j]
                    };
                    foreach (var shot in player.Shots)
                    {
                        if (shot.Letter == location.Letter && shot.Number == location.Number)
                        {
                            if (shot.Status == GridLocationStatus.Hit)
                            {
                                ConsoleHelper.DisplayMessage("Hit");
                            }
                            else if (shot.Status == GridLocationStatus.Miss)
                            {
                                ConsoleHelper.DisplayMessage("Miss");
                            }
                            else
                            {
                                ConsoleHelper.DisplayMessage($" {location.Letter}{location.Number} ");
                            }
                        }
                    }
                }
                ConsoleHelper.Display(string.Empty);
            }
        }

        public bool RequestForShot(PlayerFleetModel player, PlayerFleetModel opponent)
        {
            bool isValidShot = false;
            bool isAHit = false;
            do
            {
                var userInput = ConsoleHelper.RequestInput($"{player.FullName}, where you would like to fire: ");
                (string letter, int number, isValidShot) = ValidateGridLocation(userInput);
                if (isValidShot && IsValidLocation(letter, number, player, false, true))
                {
                    foreach (var ship in opponent.Ships)
                    {
                        if (ship.Letter == letter && ship.Number == number)
                        {
                            if (ship.Status == GridLocationStatus.Ship)
                            {
                                ship.Status = GridLocationStatus.Sunk;
                                player.Shots.Where(s => s.Letter == letter && s.Number == number).Single().Status = GridLocationStatus.Hit;
                                isAHit = true;
                            }
                            else
                            {
                                player.Shots.Where(s => s.Letter == letter && s.Number == number).Single().Status = GridLocationStatus.Miss;
                            }
                        }
                    }
                }
                else
                {
                    Console.Write("That was not a valid shot, ");
                    isValidShot = false;
                }

            } while (isValidShot == false);
            return isAHit;
        }

        public bool WinnerCheck(PlayerFleetModel opponent)
        {
            bool output = false;
            output = opponent.Ships.Where(s => s.Status == GridLocationStatus.Sunk).Count() == 5;
            return output;
        }
    }
}
