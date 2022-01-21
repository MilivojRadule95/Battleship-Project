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
                RecrodPlayerShot(activePlayer, opponent);

                // Determine if the game is over -> do that in the GameLogic
                bool doesGameContinue = GameLogic.PlayerStillActive(opponent);

                // If over set activePlayer as the winner,
                // else, swap positions (activePlayer to opponent)
                if (doesGameContinue==true)
                {
                    //use tuple or temporary variable to swap positions??

                    //SWAP USING TEMP VARIABLE:
                    //PlayerInfoModel tempHolder = opponent;
                    //opponent = activePlayer;
                    //activePlayer = tempHolder;
                    
                    //swap using tuple:
                    (activePlayer, opponent) = (opponent, activePlayer);
                }
                else
                {
                    winner = activePlayer;
                }

            } while (winner == null);
            IdentifyTWinner(winner);

            Console.ReadLine();
        }

        private static void IdentifyTWinner(PlayerInfoModel winner)
        {
            Console.WriteLine($"Congratulations to {winner.UsersName} for winning");
            Console.WriteLine($"{winner.UsersName} took {GameLogic.GetShotCount(winner)} shots.");
        }

        private static void RecrodPlayerShot(PlayerInfoModel activePlayer, PlayerInfoModel opponent)
        {
            //Ask for a shot (do we ask for "B2" or "B" and then "2")
            //Determine what row and column that is - split it apart
            //Determine if that is a valid shot
            //Go back to beginnig if not a valid shot
            bool isValidShoot = false;
            string row = "";
            int column = 0;

            do
            {
                string shot = AskForShot(activePlayer);
                try
                {
                    (row, column) = GameLogic.SplitShotIntoRowAndColum(shot);
                    isValidShoot = GameLogic.ValidateShot(activePlayer, row, column);
                }
                catch (Exception ex)
                {
                    isValidShoot = false;
                }

                if (isValidShoot == false)
                {
                    Console.WriteLine("Invalid shot location, please try again.");
                }

            } while (isValidShoot == false);


            //Determine the results 
            bool isAHit = GameLogic.IdentifyShotResult(opponent, row, column);

            //Record results
            GameLogic.MarkShotResult(activePlayer, row, column, isAHit);

            DisplayShotResults(row, column, isAHit);
        }

        private static void DisplayShotResults(string row, int column, bool isAHit)
        {
            if (isAHit)
            {
                Console.WriteLine($"{row}{column} is a Hit!");
            }
            else
            {
                Console.WriteLine($"{row}{column} is a miss.");
            }
        }

        private static string AskForShot(PlayerInfoModel player)
        {
            Console.WriteLine($"{ player.UsersName }, please enter your shot selection: ");
            string output = Console.ReadLine();

            return output; 
        }

        private static void DisplayShotGrid(PlayerInfoModel activePlayer)
        {
            string currentRow = activePlayer.ShotGrid[0].SpotLetter;

            foreach (var gridSpot in activePlayer.ShotGrid)
            {
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
                    Console.Write(" X  ");

                }
                else if (gridSpot.Status == GridSpotStatus.Miss)
                {
                    Console.Write(" O  ");
                }
                else
                {
                    Console.Write(" ?  ");
                }
            }
            Console.WriteLine();
            Console.WriteLine();
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

                bool isValidLocation = false;

                try
                {
                    isValidLocation = GameLogic.PlaceShip(model, location);
                }
                catch (Exception ex)
                {

                    Console.WriteLine("Erorr" + ex.Message);
                }

                if (isValidLocation == false)
                {
                    Console.WriteLine("That was not a valid location, please try again.");
                }

            } while (model.ShipLocations.Count < 5);
        }
    }
}
