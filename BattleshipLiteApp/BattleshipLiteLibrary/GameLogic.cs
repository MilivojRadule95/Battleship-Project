﻿using BattleshipLiteLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipLiteLibrary
{
    public static class GameLogic //here is static class because there's no need to store data inside it. 
    {   //It will only contain logic methods that can be reused.
        public static void InitalizeGrid(PlayerInfoModel model)
        {
            List<string> letters = new List<string>
            {
                "A",
                "B",
                "C",
                "D",
                "E",
               
            };
            List<int> numbers = new List<int>
            {
                1,
                2,
                3,
                4,
                5
            };
            foreach (string letter in letters)
            {
                foreach (int number in numbers)
                {
                    AddGridSpot(model, letter, number);
                }

            }
        }

        public static bool PlayerStillActive(PlayerInfoModel opponent)
        {
            throw new NotImplementedException();
        }

        private static void AddGridSpot(PlayerInfoModel model, string letter, int number)
        {
            GridSpotModel spot = new GridSpotModel
            {
                SpotLetter = letter,
                SpotNumber = number,
                Status = GridSpotStatus.Empty
            };
            
            model.ShotGrid.Add(spot);
        }

        public static bool PlaceShip(PlayerInfoModel model, string location)
        {
            throw new NotImplementedException();
        }

        public static int GetShotCount(PlayerInfoModel winner)
        {
            throw new NotImplementedException();
        }

        public static (string row, int column) SplitShotIntoRowAndColum(string shot)
        {
            throw new NotImplementedException();
        }

        public static bool ValidateShot(PlayerInfoModel activePlayer, string row, int column)
        {
            throw new NotImplementedException();
        }

        public static bool IdentifyShotResult(PlayerInfoModel opponent, string row, int column)
        {
            throw new NotImplementedException();
        }

        public static void MarkShotResult(PlayerInfoModel activePlayer, string row, int column, bool isAHit)
        {
            throw new NotImplementedException();
        }
    }
}
