using System;
using NUnit.Framework;
using SudokuMobileApp;


namespace SudokuMobile.Specs
{
    [TestFixture]
    public class BoardGeneratorTest
    {
        private BoardGenerator _boardGenerator;

        [SetUp]
        public void Setup()
        {
            _boardGenerator = new BoardGenerator();
        }


        [Test]
        public void CheckCreationOfBoard()
        {
            var board = _boardGenerator.OnInitializeBoard();
            Assert.True(board != null && board.Length == 81);
        }

        [Test]
        public void ValidateBoardCheckerWithEmptyCells()
        {
            var board = _boardGenerator.OnInitializeBoard();          
            Assert.True(_boardGenerator.OnCheckBoard(board) == false);
        }
    }
}