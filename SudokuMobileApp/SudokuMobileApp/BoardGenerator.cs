using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace SudokuMobileApp
{
    class BoardGenerator
    {
        private static string[] _fullBoard;

        public bool OnCheckBoard(string[] board)
        {
            return board == _fullBoard;
        }

        public string[] OnInitializeBoard(string boardsBoard)
        {
            var boardText = OnReadBoardFile(boardsBoard).Replace("\r\n", " ");
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