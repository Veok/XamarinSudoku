using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace SudokuMobileApp
{
    internal class BoardGenerator
    {
        private static string[] _fullBoard;

        /**
         *@param board - array that holds board filled by user
         * Function OnCheckBoard that checks board validity
         */
        public bool OnCheckBoard(string[] board)
        {
            return board == _fullBoard;
        }
        /**
         *@param boardPath - string that hold path to board file
         * Function that initialize and generates new board with random removed numbers
         */
        public string[] OnInitializeBoard(string boardPath)
        {
            var boardText = OnReadBoardFile(boardPath).Replace("\r\n", " ");
            var textSplit = boardText.Split(' ');
            _fullBoard = boardText.Split(' ');
            var random = new Random();
            if (textSplit.Length > 1)
            {
                for (var i = 0; i < 8; i++)
                {
                    var randomIndex = random.Next(0, 81);
                    textSplit[randomIndex] = "";
                }
            }

            return textSplit;
        }
        /**
         *@param path - path to board file
         * Function that reads board from txt files
         */
        private static string OnReadBoardFile(string path)
        {
            var random = new Random(DateTime.Now.Millisecond);
            var boardNumber = random.Next(1, 20);

            var assembly = typeof(BoardGenerator).GetTypeInfo().Assembly;
            var name = path + boardNumber + ".txt";
            var assemblies = assembly.GetManifestResourceNames();
            var stream = assembly.GetManifestResourceStream(name);
            try

            {
                using (var reader = new StreamReader(stream ?? throw new InvalidOperationException()))
                {
                    var text = reader.ReadToEnd();
                    return text;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            return string.Empty;
        }
    }
}