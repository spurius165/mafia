using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mafia
{
	public class MafiaWinDeadViewsModel : ContentPage
	{
		public ICommand Menu { get; set; }

		private Page _page;

		public MafiaWinDeadViewsModel(Page page)
		{
			_page = page;
			Menu = new Command(OpenMenu);
		}

		public MafiaWinDeadViewsModel()
		{
		}

		private async void OpenMenu()
		{
			var app = (App)Application.Current; // без вовзврата на 
			app.MainPage = new NavigationPage(new StartingPage()); // предыдущую страни
		}
	}
}

