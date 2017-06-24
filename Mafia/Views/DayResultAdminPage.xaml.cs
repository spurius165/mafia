using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Mafia
{
	public partial class DayResultAdminPage : ContentPage
	{
		public DayResultAdminPage()
		{
			InitializeComponent();
            this.Dead.Text= GameService.Instance._lastKill;
			this.BindingContext = new DayResultAdminViewsModel(this, GameService.Instance);
		}

		protected override void OnAppearing() // убрать линию сверху
		{
			base.OnAppearing();
			NavigationPage.SetHasNavigationBar(this, false);
		}
	}
}
