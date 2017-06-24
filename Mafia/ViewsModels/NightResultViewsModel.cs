using System.Collections.Generic; using System.Collections.ObjectModel; using System.Threading.Tasks; using Newtonsoft.Json; using Xamarin.Forms;  namespace Mafia { 	public class NightResultViewsModel : ContentPage 	{ 		private readonly IGameService _gameService; //!! 		public int i; 		private Page _page;  		public NightResultViewsModel(Page page, IGameService gameService) //!!
		{ 			var i = 0; 			_gameService = gameService; //!! 			_gameService.OnReceive += GameService_OnReceive; //!!
		}   		private void GameService_OnReceive(object sender, Message e) //принимает данные сервера
		{ 			Device.BeginInvokeOnMainThread(async () => 			{ 				if ((e.UserMessage == "Day") && (i == 0)) 				{ 					i++; 					var app = (App)Application.Current; // без вовзврата на  					app.MainPage = new NavigationPage(new DayPage()); // предыдущую страницу

				} 			}); 		} 	} }   