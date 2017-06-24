using System;

using Xamarin.Forms;

namespace Mafia
{
	public class StartGameUserModel : ContentPage
	{
		public StartGameUserModel()
		{
		}

		public int id { get; set; }
		public string message { get; set; }
		public string type { get; set; }
		public string error { get; set; }
	}
}

