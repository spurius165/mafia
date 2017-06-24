using Xamarin.Forms;

namespace Mafia
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			var Fpage = new NavigationPage(new LoginPage());
			Fpage.BarBackgroundColor = Color.FromHex("000000");
			MainPage = Fpage;
			//MainPage = new NavigationPage(new StartGameUserPage());
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
