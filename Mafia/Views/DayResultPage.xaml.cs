using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Mafia
{
	public partial class DayResultPage : ContentPage
	{
		public DayResultPage()
		{
			InitializeComponent();
			this.Dead.Text=GameService.Instance._lastKill;
			this.BindingContext = new DayResultViewsModel(this, GameService.Instance);
		}

		protected override void OnAppearing() // убрать линию сверху
		{
			base.OnAppearing();
			NavigationPage.SetHasNavigationBar(this, false);
		}
	}
}
