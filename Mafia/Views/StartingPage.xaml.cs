using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Mafia
{
	public partial class StartingPage : ContentPage
	{
		public StartingPage()
		{
			InitializeComponent();
			this.BindingContext = new StartingPageViewsModel(this);
			//NavigationPage.BarBackgroundColorProperty = Color.FromHex("00ff00");

		}

		protected override void OnAppearing() // убрать линию сверху
		{
			base.OnAppearing();
			NavigationPage.SetHasNavigationBar(this, false);
		}
	}
}