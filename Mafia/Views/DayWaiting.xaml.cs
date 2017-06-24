using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Mafia
{
	public partial class DayWaiting : ContentPage
	{
		public DayWaiting()
		{
			InitializeComponent();
			this.BindingContext = new DayWaitingViewsModel(this, GameService.Instance);
		}


		protected override void OnAppearing() // убрать линию сверху
		{
			base.OnAppearing();
			NavigationPage.SetHasNavigationBar(this, false);
		}
	}
}
