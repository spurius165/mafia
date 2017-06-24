using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Mafia
{
	public partial class DayResultDeadPage : ContentPage
	{
		public DayResultDeadPage()
		{
			InitializeComponent();
            this.BindingContext = new DayResultDeadViewsModel(this, GameService.Instance);
            this.ImgRole.Source = GameService.Instance._userRoleImg;
		}

		protected override void OnAppearing() // убрать линию сверху
		{
			base.OnAppearing();
			NavigationPage.SetHasNavigationBar(this, false);
		}
	}
}
