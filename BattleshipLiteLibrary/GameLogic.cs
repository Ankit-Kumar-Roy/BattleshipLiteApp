using BattleshipLiteLibrary.Models;
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
                (string letter, int number, bool isValidInput) = GetGridLocation(userInput);
                if (isValidInput && IsValidLocation(letter, number, firstPlayer))
                {
                    var ship = new GridLocationModel
                    {
                        Letter = letter.ToUpper(),
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

        private static bool IsValidLocation(string letter, int number, PlayerFleetModel firstPlayer)
        {
            bool output = true;
            foreach (var ship in firstPlayer.Ships)
            {
                if (ship.Letter == letter && ship.Number == number)
                {
                    output = false;
                }
            }

            return output;
        }

        private static (string letter, int number, bool isValidInput) GetGridLocation(string userInput)
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

            return (letter, number, isValidInput);
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
    }
}
