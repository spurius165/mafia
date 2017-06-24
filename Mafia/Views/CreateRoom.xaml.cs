using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Mafia
{
	public partial class CreateRoom : ContentPage
	{
		public CreateRoom()
		{
			InitializeComponent();
			this.BindingContext = new CreateRoomViewsModel(this);
		}


	}
}
