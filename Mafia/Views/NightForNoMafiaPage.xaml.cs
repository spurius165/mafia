using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Mafia
{
	public partial class NightForNoMafiaPage : ContentPage
	{
		public NightForNoMafiaPage()
		{
			InitializeComponent();
            this.BindingContext = new NightForNoMafiaViewsModel(this, GameService.Instance);
		}


		protected override void OnAppearing() // убрать линию сверху
		{
			base.OnAppearing();
			NavigationPage.SetHasNavigationBar(this, false);
		}
	}
}
