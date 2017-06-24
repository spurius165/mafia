using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mafia
{
	public class MirWinDeadViewModel : ContentPage
	{
	public ICommand Menu { get; set; }

	private Page _page;

	public MirWinDeadViewModel(Page page)
	{
		_page = page;
		Menu = new Command(OpenMenu);
	}

	public MirWinDeadViewModel()
	{
	}

	private async void OpenMenu()
	{
		var app = (App)Application.Current; // без вовзврата на 
		app.MainPage = new NavigationPage(new StartingPage()); // предыдущую страни
			}
	}
}

