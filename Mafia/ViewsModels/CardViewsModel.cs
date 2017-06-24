using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mafia
{
	public class CardViewsModel : ContentPage
	{
		public ICommand StartPlay { get; set; }

		private Page _page;

		public CardViewsModel(Page page)
		{
			_page = page;
			StartPlay = new Command(OpenDayPage);
		}

		public CardViewsModel()
		{
		}

		private async void OpenDayPage()
		{
			var app = (App)Application.Current; // без вовзврата на 
			app.MainPage = new NavigationPage(new DayPage()); // предыдущую страницу
		}
	}
}

