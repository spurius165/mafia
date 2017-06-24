using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Mafia
{
	public partial class MafiaWinPage : ContentPage
	{
		public MafiaWinPage()
		{
			InitializeComponent();
            this.Dead.Text= GameService.Instance._lastKill;
            this.BindingContext = new MafiaWinViewsModel(this);
		}

		protected override void OnAppearing() // убрать линию сверху
		{
			base.OnAppearing();
			NavigationPage.SetHasNavigationBar(this, false);
		}
	}
}
