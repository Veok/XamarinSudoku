using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Xamarin.Forms.Internals;

namespace SudokuMobileApp
{
    interface IBoardGenerator
    {
        bool CheckBoard();

        string[] InitializeBoard();
    }

    class BoardGenerator : IBoardGenerator
    {
        
        public bool CheckBoard()
        {
            throw new NotImplementedException();
        }

        public string[] InitializeBoard()
        {
            var boardText = ReadBoardFile().Replace("\r\n", " ");
            var textSplit = boardText.Split(' ');
            return textSplit;
        }

        private string ReadBoardFile()
        {
            var random = new Random(DateTime.Now.Millisecond);
            var boardNumber = random.Next(1, 20);

            var assembly = typeof(BoardGenerator).GetTypeInfo().Assembly;
            var name = "SudokuMobileApp.Droid.Boards.board" + boardNumber + ".txt";
            var stream = assembly.GetManifestResourceStream(name);
            try

            {
                using (var reader = new System.IO.StreamReader(stream))
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