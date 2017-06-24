using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Mafia
{
	public class DayViewsModel : ContentPage
	{
		public string PeopleName { get; set; }
		private readonly IGameService _gameService; //!!

		private Page _page;

		public DayViewsModel(Page page, IGameService gameService) //!!
		{
			_gameService = gameService; //!!
			_gameService.OnReceive += GameService_OnReceive; //!!
			_page = page;
		}

		public ObservableCollection<DayModel> People { get; set; } = new ObservableCollection<DayModel>
		{

		};

		private void GameService_OnReceive(object sender, Message e) //принимает данные сервера
		{
			Device.BeginInvokeOnMainThread(async () =>
			{
				
			});
		}

		public async Task LoadPeople()
		{
			var json = "{\"UserName\":\"" + GameService.Instance._userName + "\",\"UserRoom\":\"" + GameService.Instance._userRoom +"\"}";
			var response = await DataService.GetInstance().GetPeopleAsync(json);
			var people = JsonConvert.DeserializeObject<List<DayModel>>(response);
			foreach (var man in people)
			{
				People.Add(man);

			}
		}
	}
}

