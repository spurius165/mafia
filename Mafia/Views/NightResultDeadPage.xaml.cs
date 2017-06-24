using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Mafia
{
	public partial class NightResultDeadPage : ContentPage
	{
		public NightResultDeadPage()
		{
			InitializeComponent();
			this.BindingContext = new NightResultDeadViewsModel(this, GameService.Instance);
			this.ImgRole.Source = GameService.Instance._userRoleImg;
		}

		protected override void OnAppearing() // убрать линию сверху
		{
			base.OnAppearing();
			NavigationPage.SetHasNavigationBar(this, false);
		}
	}
}
