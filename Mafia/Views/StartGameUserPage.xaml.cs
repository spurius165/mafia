using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mafia
{
	public partial class StartGameUserPage : ContentPage
	{
		public string UserRoom;
		public StartGameUserPage()
		{
			var UserRoom = GameService.Instance._userRoom;
			InitializeComponent();
			this.BindingContext = new StartGameUserViewsModel(this, GameService.Instance); //!!
			this.RoomNameHere.Text = UserRoom;
		}

		protected override void OnAppearing() // убрать линию сверху
		{
			base.OnAppearing();
			NavigationPage.SetHasNavigationBar(this, false);
		}
	}
}
