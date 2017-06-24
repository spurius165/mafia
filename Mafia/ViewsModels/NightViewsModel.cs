using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Mafia
{
	public class NightViewsModel : ContentPage
	{
		public string NoMafiaName { get; set; }
		private readonly IGameService _gameService; //!!

		private Page _page;

		public NightViewsModel(Page page, IGameService gameService) //!!
		{
			_gameService = gameService; //!!
			_gameService.OnReceive += GameService_OnReceive; //!!
			_page = page;
		}

		public ObservableCollection<NightModel> NoMafia { get; set; } = new ObservableCollection<NightModel>
		{

		};

		private void GameService_OnReceive(object sender, Message e) //принимает данные сервера
		{
			Device.BeginInvokeOnMainThread(async () =>
			{
				


			});
		}

		public async Task LoadNoMafia()
		{
			var json = "{\"UserName\":\"" + GameService.Instance._userName + "\",\"UserRoom\":\"" + GameService.Instance._userRoom + "\"}";
			var response = await DataService.GetInstance().GetNoMafiaAsync(json);
			var nomafia = JsonConvert.DeserializeObject<List<NightModel>>(response);
			foreach (var man in nomafia)
			{
				NoMafia.Add(man);

			}
		}
	}
}
