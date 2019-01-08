using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Xamarin.Forms.Internals;

namespace SudokuMobileApp
{
    class BoardGenerator
    {
        private static string[] _fullBoard;

        public bool OnCheckBoard(string[] board)
        {
            return board == _fullBoard;
        }

        public string[] OnInitializeBoard()
        {
            var boardText = OnReadBoardFile().Replace("\r\n", " ");
            var textSplit = boardText.Split(' ');
            _fullBoard = boardText.Split(' ');
            var random = new Random();
            for (var i = 0; i < 8; i++)
            {
                var randomIndex = random.Next(0, 81);
                textSplit[randomIndex] = "";
            }

            return textSplit;
        }

        private static string OnReadBoardFile()
        {
            var random = new Random(DateTime.Now.Millisecond);
            var boardNumber = random.Next(1, 20);

            var assembly = typeof(BoardGenerator).GetTypeInfo().Assembly;
            var name = "SudokuMobileApp.Droid.Boards.board" + boardNumber + ".txt";
            var stream = assembly.GetManifestResourceStream(name);
            try

            {
                using (var reader = new StreamReader(stream))
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