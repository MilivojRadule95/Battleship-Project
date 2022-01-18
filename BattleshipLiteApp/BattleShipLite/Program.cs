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

            PlayerInfoModel player1 = CreatePlayer("Player 1");
            PlayerInfoModel player2 = CreatePlayer("Player 2");

            Console.ReadLine();
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
