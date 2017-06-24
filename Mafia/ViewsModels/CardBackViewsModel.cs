using System;
using System.Windows.Input;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Mafia
{
	public class RoleModel
	{
		public int role { get; set; }
	}

	public class CardBackViewsModel : ContentPage
	{
		public ICommand ShowCard { get; set; }

		private Page _page;

		public CardBackViewsModel(Page page)
		{
			_page = page;
			ShowCard = new Command(OpenCardPage);
		}

		public CardBackViewsModel()
		{
		}

		private async void OpenCardPage()
		{

			var json = "{\"UserName\":\"" + GameService.Instance._userName + "\"}"; // 
			var response = await DataService.GetInstance().GetRole(json);
			var answer = JsonConvert.DeserializeObject<RoleModel>(response);

			if (answer.role == 0)
			{
				GameService.Instance.GetRoleImg("mirniy.png");
			}
			else
			{
				GameService.Instance.GetRoleImg("mafia.png");
			}
			var app = (App)Application.Current; // без вовзврата на 
			app.MainPage = new NavigationPage(new CardPage()); // предыдущую страницу

		}
	}
}

