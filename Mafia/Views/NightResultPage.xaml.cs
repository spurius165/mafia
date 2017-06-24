using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Mafia
{
	public partial class NightResultPage : ContentPage
	{
		public NightResultPage()
		{
			InitializeComponent();
			this.Dead.Text = GameService.Instance._lastKill;
			this.BindingContext = new NightResultViewsModel(this, GameService.Instance);
		}

		protected override void OnAppearing() // убрать линию сверху
		{
			base.OnAppearing();
			NavigationPage.SetHasNavigationBar(this, false);
		}
	}
}
