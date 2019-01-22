using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;

namespace SudokuMobileApp
{
    public partial class MainPage : ContentPage
    {

        Button btnStart, btnCheck;
        TextView txtTimer;
        Timer timer;

        int mins = 0, sec = 0;

        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

        }

        private async void OnStartGame(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GameBoard());
                timer = new Timer();
                timer.Interval = 1; // 1 milliseconds  
                timer.Elapsed += Timer_Elapsed;
                timer.Start();
        }
        
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            sec++;
            if (sec == 60)
            {
                mins++;
                sec = 0;
            }
            RunOnUiThread(() =>
            {
                txtTimer.Text = String.Format("(0):(1:00)", mins, sec);
            });

        }
    }
}
