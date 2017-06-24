using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Mafia
{
	public partial class MafiaWinDeadPage : ContentPage
	{
		public MafiaWinDeadPage()
		{
			InitializeComponent();
		}


		protected override void OnAppearing() // убрать линию сверху
		{
			base.OnAppearing();
			NavigationPage.SetHasNavigationBar(this, false);
		}
	}
}
