using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Mafia
{
	public partial class NightPage : ContentPage
	{
		private NightViewsModel Night;
		NightViewsModel _viewModel;



		public NightPage()
		{
			InitializeComponent();
			this.BindingContext = _viewModel = new NightViewsModel(this, GameService.Instance);
		}
		public class KolmafModel
		{
			public string maf { get; set; }
			public string UserMessage { get; set; }
		}
		private async void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
		{
			var mafiakill = (NightModel)e.Item;
			GameService.Instance.NightKill(mafiakill.UserName);
			/*
			//GameService.Instance.GetRoomName(useroom.Name);
			GameService.Instance.Connect(GameService.Instance._userName);
			GameService.Instance.NewUser(GameService.Instance._userName);*/
			var k = await DataService.GetInstance().GetKolMafAsync();
			var answeri = JsonConvert.DeserializeObject<KolmafModel>(k);
			if (answeri.maf == "one")
			{
			var json = "{\"UserRoom\":\"" + GameService.Instance._userRoom + "\"} "; // создание комнаты
			var response = await DataService.GetInstance().GetAdmin(json);
			var answer = JsonConvert.DeserializeObject<AdminModel>(response);

			GameService.Instance.GetLastKill(answeri.UserMessage);
			if (answeri.UserMessage == GameService.Instance._userName)
			{
			var app = (App)Application.Current; // без вовзврата на 
			app.MainPage = new NavigationPage(new NightResultDeadPage()); // предыдущую страницу
			//}
			}
			else
			{
			if (GameService.Instance._userName == answer.admin)
			{
			var app = (App)Application.Current; // без вовзврата на 
			app.MainPage = new NavigationPage(new NightResultAdminPage()); // предыдущую страницу
			}
			else
			{
			var app = (App)Application.Current; // без вовзврата на 
			app.MainPage = new NavigationPage(new NightResultPage()); // предыдущую страницу
			}
			}
			}
			else
			{
			var app = (App)Application.Current; // без вовзврата на 
			app.MainPage = new NavigationPage(new NightWaiting());
			}
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();

			await _viewModel.LoadNoMafia();

			NavigationPage.SetHasNavigationBar(this, false);
		}

	}
}
