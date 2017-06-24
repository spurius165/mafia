using System; using System.Collections.Generic; using System.Collections.ObjectModel; using System.ComponentModel; using System.Runtime.CompilerServices; using System.Threading.Tasks; using System.Windows.Input; using Newtonsoft.Json; using Xamarin.Forms;  namespace Mafia { 	public class StartGameAdminViewsModel 	{ 		public ICommand StartGame { get; set; } 		public ICommand GoOut { get; set; } 		public int i; 		private readonly IGameService _gameService; //!!   		public string UserRoom = GameService.Instance._userRoom;  		public ObservableCollection<string> Logs { get; set; } = new ObservableCollection<string>
		{  		};  		private Page _page;  		public StartGameAdminViewsModel(Page page, IGameService gameService) //!!
		{ 			var i = 0; 			_gameService = gameService; //!! 			_gameService.OnReceive += GameService_OnReceive; //!! 			_page = page; 			StartGame = new Command(StartGameCommand); 			GoOut = new Command(GoOutCommand); 		}  		public async void StartGameCommand() 		{ 			GameService.Instance.StartGame();
			//await _page.Navigation.PushAsync(new CardBackPage());
		}  		private async void GoOutCommand() 		{ 			GameService.Instance.DelUser(GameService.Instance._userName); 			GameService.Instance.Disconnect(); 			var app = (App)Application.Current; 			app.MainPage = new NavigationPage(new StartingPage()); 		}  		private void GameService_OnReceive(object sender, Message e) //принимает данные сервера
		{ 			Device.BeginInvokeOnMainThread(async () => 			{ 				Logs.Insert(0, e.UserMessage); // вставляет новое сообщение в начало 				if ((e.UserMessage == "Game Started") & (i == 0)) 				{ 					var app = (App)Application.Current; 					app.MainPage = new NavigationPage(new CardBackPage()); 					i++; 				} 			}); 		}


		//public async Task LoadLogs()
		//{
		//	var json = "{\"Room\":\"" + UserRoom + "\"}";
		//	var response = await DataService.GetInstance().GetLogAsync(json);
		//	var logs = JsonConvert.DeserializeObject<List<StartGameAdminModel>>(response);
		//	foreach (var log in logs)
		//	{
		//		Logs.Add(log);
		//	}
		//}

	} } 