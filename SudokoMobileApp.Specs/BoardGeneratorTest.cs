using SudokuMobileApp;
using Xunit;

namespace SudokoMobileApp.Specs
{
    public class BoardGeneratorTest
    {
        private readonly BoardGenerator _boardGenerator;

        public BoardGeneratorTest()
        {
            _boardGenerator = new BoardGenerator();
        }

        /**Test that check correctness of board generation **/
        [Fact]
        public void OnCheckCreationOfBoard()
        {
            var board = _boardGenerator.OnInitializeBoard("SudokoMobileApp.Specs.Boards.board");
            Assert.True(board != null && board.Length == 81);
        }

        /**Test that check board to have empty cells **/
        [Fact]
        public void OnValidateBoardCheckerWithEmptyCells()
        {
            var board = _boardGenerator.OnInitializeBoard("SudokoMobileApp.Specs.Boards.board");
            Assert.True(_boardGenerator.OnCheckBoard(board) == false);
        }
    }
}