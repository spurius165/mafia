using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Mafia
{
	public partial class CardPage : ContentPage
	{
		public CardPage()
		{
			InitializeComponent();
			this.BindingContext = new CardViewsModel(this);
			this.ImgRole.Source = GameService.Instance._userRoleImg;
		}

		protected override void OnAppearing() // убрать линию сверху
		{
			base.OnAppearing();
			NavigationPage.SetHasNavigationBar(this, false);
		}
	}
}
