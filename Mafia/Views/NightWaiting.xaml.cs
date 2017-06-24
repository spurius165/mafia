using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Mafia
{
	public partial class NightWaiting : ContentPage
	{
		public NightWaiting()
		{
			InitializeComponent();
            this.BindingContext = new NightWaitingViewsModel(this, GameService.Instance);
		}


		protected override void OnAppearing() // убрать линию сверху
		{
			base.OnAppearing();
			NavigationPage.SetHasNavigationBar(this, false);
		}
	}
}
