using System; using Newtonsoft.Json; using Xamarin.Forms;  namespace Mafia { 	public class AdminModel
	{ 		public string admin { get; set; } 	}  	public class DayWaitingViewsModel : ContentPage 	{ 		public int i; 		private readonly IGameService _gameService; //!!  		public DayWaitingViewsModel(Page page, IGameService gameService) //!!
		{ 			var i = 0;
			_gameService = gameService; //!! 				_gameService.OnReceive += GameService_OnReceive; //!!
		}  		private void GameService_OnReceive(object sender, Message e) //принимает данные сервера
		{ 			Device.BeginInvokeOnMainThread(async () => 			{ 				try 				{ 					if ((e.UserType == "gameover") && (i == 0)) 					{ 						i++; 						if (e.UserMessage == "mir") 						{ 							GameService.Instance.GetLastKill(e.UserName); 							if (e.UserName == GameService.Instance._userName) 							{ 								var app = (App)Application.Current; // без вовзврата на  								app.MainPage = new NavigationPage(new MirWinDeadPage()); // предыдущую страницу
																																												 //}
							} 							else 							{ 								var app = (App)Application.Current; // без вовзврата на  								app.MainPage = new NavigationPage(new MirWinPage()); // предыдущую страницу
							} 						} 						if (e.UserMessage == "maf") 						{ 							GameService.Instance.GetLastKill(e.UserName); 							if (e.UserName == GameService.Instance._userName) 							{ 								var app = (App)Application.Current; // без вовзврата на  								app.MainPage = new NavigationPage(new MafiaWinDeadPage()); // предыдущую страницу
							} 							else 							{ 								var app = (App)Application.Current; // без вовзврата на  								app.MainPage = new NavigationPage(new MafiaWinPage()); // предыдущую страницу
							} 						} 					} 					else 					{ 						if ((e.UserType == "daykilling") && (i == 0)) 						{ 							i++; 							var json = "{\"UserRoom\":\"" + GameService.Instance._userRoom + "\"} "; // создание комнаты 							var response = await DataService.GetInstance().GetAdmin(json); 							var answer = JsonConvert.DeserializeObject<AdminModel>(response);  							GameService.Instance.GetLastKill(e.UserMessage);  							if (e.UserMessage == GameService.Instance._userName) 							{ 								var app = (App)Application.Current; // без вовзврата на  								app.MainPage = new NavigationPage(new DayResultDeadPage()); // предыдущую страницу
																																													//}
							} 							else 							{ 								if (GameService.Instance._userName == answer.admin) 								{ 									var app = (App)Application.Current; // без вовзврата на  									app.MainPage = new NavigationPage(new DayResultAdminPage()); // предыдущую стр
								} 								else 								{ 									var app = (App)Application.Current; // без вовзврата на  									app.MainPage = new NavigationPage(new DayResultPage()); // предыдущую страницу
								} 							} 						} 					} 				} 				catch (Exception k) 				{ 				} 			}); 		}

	} }   