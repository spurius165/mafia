using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mafia
{
	public class MafiaWinViewsModel : ContentPage
	{
		public ICommand Menu { get; set; }

		private Page _page;

		public MafiaWinViewsModel(Page page)
		{
			_page = page;
			Menu = new Command(OpenMenu);
		}

		public MafiaWinViewsModel()
		{
		}

		private async void OpenMenu()
		{
			var app = (App)Application.Current; // без вовзврата на 
			app.MainPage = new NavigationPage(new StartingPage()); // предыдущую страницу
		}
	}
}

