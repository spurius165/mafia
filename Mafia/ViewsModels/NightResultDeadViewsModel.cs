using System;

using Xamarin.Forms;

namespace Mafia
{
	public class NightResultDeadViewsModel : ContentPage
	{
		private readonly IGameService _gameService; //!!
		public int i;
		private Page _page;

		public NightResultDeadViewsModel(Page page, IGameService gameService) //!!
		{
		i = 0;
		_gameService = gameService; //!!
		_gameService.OnReceive += GameService_OnReceive; //!!
		}

		private void GameService_OnReceive(object sender, Message e) //принимает данные сервера
		{
			Device.BeginInvokeOnMainThread(async () =>
			{
				if ((e.UserType == "gameover") && (i == 0))
						{
							i++;
							if (e.UserMessage == "mir")
							{
								GameService.Instance.GetLastKill(e.UserName);
								if (e.UserName == GameService.Instance._userName)
								{
									var app = (App)Application.Current; // без вовзврата на 
									app.MainPage = new NavigationPage(new MirWinDeadPage()); // предыдущую страницу
																																														 //}
								}
								else
								{
									var app = (App)Application.Current; // без вовзврата на 
									app.MainPage = new NavigationPage(new MirWinPage()); // предыдущую страницу
								}
							}
							if (e.UserMessage == "maf")
							{
								GameService.Instance.GetLastKill(e.UserName);
								if (e.UserName == GameService.Instance._userName)
								{
									var app = (App)Application.Current; // без вовзврата на 
									app.MainPage = new NavigationPage(new MafiaWinDeadPage()); // предыдущую страницу
								}
								else
								{
									var app = (App)Application.Current; // без вовзврата на 
									app.MainPage = new NavigationPage(new MafiaWinPage()); // предыдущую страницу
								}
							}
						}
			});
		}
	}
}


