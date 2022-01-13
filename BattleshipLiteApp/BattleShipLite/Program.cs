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
            Console.ReadLine();
        }
        private static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to the Battleship Lite");
            Console.WriteLine("Created by Milivoj Radonic");
            Console.WriteLine();
        }
        private static PlayerInfoModel CreatePlayer()
        {
            PlayerInfoModel output = new PlayerInfoModel();

            //Ask user for their name
            output.UsersName = AskForUsersName();
            //Load up the shot grid
            output.ShotGrid
            //Ask the user for their 5 ships placments
            //Clear
        }
        private static string AskForUsersName()
        {
            Console.Write("What is yiur name: ");
            string output = Console.ReadLine();
            return output;
        }
    }
}
