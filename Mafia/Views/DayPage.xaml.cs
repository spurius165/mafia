using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Mafia
{
	public partial class DayPage : ContentPage
	{
		private DayViewsModel Day;
		DayViewsModel _viewModel;



		public DayPage()
		{
		InitializeComponent();
		//Day = new DayViewsModel(this);
		this.BindingContext = _viewModel = new DayViewsModel(this, GameService.Instance);
		}

		private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
		{
			var userkill = (DayModel)e.Item;
			GameService.Instance.DayKill(userkill.UserName);
		/*
		//GameService.Instance.GetRoomName(useroom.Name);
		GameService.Instance.Connect(GameService.Instance._userName);
		GameService.Instance.NewUser(GameService.Instance._userName);*/
		var app = (App)Application.Current; // без вовзврата на 
		app.MainPage = new NavigationPage(new DayWaiting());
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();

			await _viewModel.LoadPeople();
		
			NavigationPage.SetHasNavigationBar(this, false);
		}

	}
}
