using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mafia
{
	public class LoginPageViewsModel 
	{
		public ICommand CreateRoomPage { get; set; }
		public string UserName { get; set; }
		private Page _page;

		public LoginPageViewsModel(Page page)
		{
			_page = page;
			CreateRoomPage = new Command(OpenCreateRoomPage);
		}

		public LoginPageViewsModel()
		{
		}

		private async void OpenCreateRoomPage()
		{
			GameService.Instance.GetUserName(UserName);
			var app = (App)Application.Current; // без вовзврата на 
			app.MainPage = new NavigationPage(new StartingPage()); // предыдущую страницу
		}

	}
}

