using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Mafia
{
	public partial class MirWinDeadPage : ContentPage
	{
		public MirWinDeadPage()
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
