using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mafia
{
	public class MirWinViewsModel : ContentPage
	{
		public ICommand Menu { get; set; }

		private Page _page;

		public MirWinViewsModel(Page page)
		{
			_page = page;
			Menu = new Command(OpenMenu);
		}

		public MirWinViewsModel	()
		{
		}

		private async void OpenMenu()
		{
			var app = (App)Application.Current; // без вовзврата на 
			app.MainPage = new NavigationPage(new StartingPage()); // предыдущую страницу
		}
	}
}

