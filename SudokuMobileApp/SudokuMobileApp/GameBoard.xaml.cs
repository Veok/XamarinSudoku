using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace SudokuMobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameBoard : ContentPage
    {
        private static string[] _textBoard;
        private readonly BoardGenerator _boardGenerator = new BoardGenerator();

        public GameBoard()
        {
            InitializeComponent();
            _textBoard = _boardGenerator.OnInitializeBoard();
            NavigationPage.SetHasNavigationBar(this, false);
            Board.Children.Add(OnGenerateBoard());
        }

        public void OnCheckGame(object sender, EventArgs e)
        {
            var x = _boardGenerator.OnCheckBoard(_textBoard);
            var y = 7;
        }


        public async void OnReset(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GameBoard());
        }

        private static Grid OnGenerateBoard()
        {
            var gridBoard = new Grid();
            gridBoard.Margin = new Thickness(20, 15, 20, 20);
            GenerateGridRows(gridBoard);
            GenerateGridColums(gridBoard);
            OnGenerateCells(gridBoard);
            return gridBoard;
        }

        private static void OnGenerateCells(Grid gridBoard)
        {
            gridBoard.BackgroundColor = Color.Black;
            var counter = 0;

            gridBoard.ColumnDefinitions.ForEach(y =>
            {
                var rowCounter = 0;
                gridBoard.RowDefinitions.ForEach(x =>
                {
                    gridBoard.Children.Add(
                        new XEntry()
                        {
                            BackgroundColor = Color.White,
                            TextColor = Color.Black,
                            PlaceholderColor = Color.Black,
                            HorizontalTextAlignment = TextAlignment.Center,
                            FontSize = 11,
                            ClassId = counter.ToString(),
                            Keyboard = Keyboard.Numeric,
                        },
                        counter, rowCounter);
                    rowCounter++;
                });
                counter++;
            });
            gridBoard.ColumnSpacing = 1.5;
            gridBoard.RowSpacing = 1.5;

            for (var i = 0; i < 81; i++)
            {
                var entry = (XEntry) gridBoard.Children[i];
                entry.Text = _textBoard[i];
            }
        }

        private static void GenerateGridColums(Grid gridBoard)
        {
            gridBoard.ColumnDefinitions = new ColumnDefinitionCollection()
            {
                new ColumnDefinition(),
                new ColumnDefinition(),
                new ColumnDefinition(),
                new ColumnDefinition(),
                new ColumnDefinition(),
                new ColumnDefinition(),
                new ColumnDefinition(),
                new ColumnDefinition(),
                new ColumnDefinition()
            };
        }

        private static void GenerateGridRows(Grid gridBoard)
        {
            gridBoard.RowDefinitions = new RowDefinitionCollection()
            {
                new RowDefinition() {Height = GridLength.Star},
                new RowDefinition() {Height = GridLength.Star},
                new RowDefinition() {Height = GridLength.Star},
                new RowDefinition() {Height = GridLength.Star},
                new RowDefinition() {Height = GridLength.Star},
                new RowDefinition() {Height = GridLength.Star},
                new RowDefinition() {Height = GridLength.Star},
                new RowDefinition() {Height = GridLength.Star},
                new RowDefinition() {Height = GridLength.Star},
            };
        }
    }
}