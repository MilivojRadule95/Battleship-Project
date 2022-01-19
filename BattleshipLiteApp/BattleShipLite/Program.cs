using BattleshipLiteLibrary;
using BattleshipLiteLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipLite
{
    class Program
    {
        static void Main(string[] args)
        {
            WelcomeMessage();

            PlayerInfoModel activePlayer = CreatePlayer("Player 1");
            PlayerInfoModel opponent = CreatePlayer("Player 2");
            PlayerInfoModel winner = null;

            do
            {
                // Display grid from activePlayer on where they fired
                DisplayShotGrid(activePlayer);
                // Ask activePlayer for a shot
                // Determine if it's a valid shot(keep looping until he gives a valid shot)
                // Determine shot result
                // Determine if the game is over
                // If over set activePlayer as the winner,
                // else, swap positions (activePlayer to opponent)
            } while (winner == null);

            Console.ReadLine();
        }

        private static void DisplayShotGrid(PlayerInfoModel activePlayer)
        {
            foreach (var gridSpot in activePlayer.ShotGrid)
            {
                string currentRow = activePlayer.ShotGrid[0].SpotLetter;
                if (gridSpot.SpotLetter != currentRow)
                {
                    Console.WriteLine();
                    currentRow = gridSpot.SpotLetter;
                }
                
                if (gridSpot.Status == GridSpotStatus.Empty)
                {
                    Console.Write($" {gridSpot.SpotLetter}{gridSpot.SpotNumber} ");
                }
                else if (gridSpot.Status == GridSpotStatus.Hit)
                {
                    Console.Write(" X ");

                }
                else if (gridSpot.Status == GridSpotStatus.Miss)
                {
                    Console.Write(" O ");
                }
                else
                {
                    Console.Write(" ? ");
                }
            }
        }

        private static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to the Battleship Lite");
            Console.WriteLine("Created by Milivoj Radonic");
            Console.WriteLine();
        }
        private static PlayerInfoModel CreatePlayer(string playerTitle)
        {
            PlayerInfoModel output = new PlayerInfoModel();

            Console.WriteLine($"Player information for {playerTitle}");

            //Ask user for their name
            output.UsersName = AskForUsersName();
            //Load up the shot grid
            GameLogic.InitalizeGrid(output);
            //Ask the user for their 5 ships placments
            ShipPlacment(output);
            //Clear
            Console.Clear();

            return output;
        }
        private static string AskForUsersName()
        {
            Console.Write("What is your name: ");
            string output = Console.ReadLine();

            return output;
        }
        private static void ShipPlacment(PlayerInfoModel model)
        {
            do
            {
                Console.Write($"Where do you want to place your ship number {model.ShipLocations.Count + 1}: ");
                string location = Console.ReadLine();

                bool isValidLocation = GameLogic.PlaceShip(model, location);

                if (isValidLocation == false)
                {
                    Console.WriteLine("That was not a valid location, please try again.");
                }

            } while (model.ShipLocations.Count < 5);
        }
    }
}
