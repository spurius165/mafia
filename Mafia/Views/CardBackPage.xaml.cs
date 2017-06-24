
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Mafia
{
	public partial class CardBackPage : ContentPage
	{
		public CardBackPage()
		{
			InitializeComponent();
            this.BindingContext = new CardBackViewsModel(this);
		}




		protected override void OnAppearing() // убрать линию сверху
		{
			base.OnAppearing();
			NavigationPage.SetHasNavigationBar(this, false);
		}
	}
}
