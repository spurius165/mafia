using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Mafia
{
	public partial class NightResultAdminPage : ContentPage
	{
		public NightResultAdminPage()
		{
			InitializeComponent();
			this.Dead.Text = GameService.Instance._lastKill;
			this.BindingContext = new NightResultAdminViewsModel(this, GameService.Instance);
		}

		protected override void OnAppearing() // убрать линию сверху
		{
			base.OnAppearing();
			NavigationPage.SetHasNavigationBar(this, false);
		}
	}
}