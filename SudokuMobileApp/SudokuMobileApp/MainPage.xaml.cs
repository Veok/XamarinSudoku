﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SudokuMobileApp
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

        }

        private async void OnStartGame(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GameBoard());

        }
    }
}
