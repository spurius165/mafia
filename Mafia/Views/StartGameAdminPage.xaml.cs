using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Mafia
{
	public partial class StartGameAdminPage : ContentPage
	{
		public string UserRoom;
		public StartGameAdminPage()
		{
		var UserRoom = GameService.Instance._userRoom;
		InitializeComponent();
		this.BindingContext = new StartGameAdminViewsModel(this, GameService.Instance); //!!
		this.RoomNameHere.Text = UserRoom;
		}

		protected override void OnAppearing() // убрать линию сверху
		{
			base.OnAppearing();
			NavigationPage.SetHasNavigationBar(this, false);
		}
	}
}