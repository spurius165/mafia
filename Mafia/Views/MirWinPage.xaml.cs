using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Mafia
{
	public partial class MirWinPage : ContentPage
	{
		public MirWinPage()
		{
            InitializeComponent();
            this.Dead.Text= GameService.Instance._lastKill;
			this.BindingContext = new MirWinViewsModel(this);
		}

		protected override void OnAppearing() // убрать линию сверху
		{
			base.OnAppearing();
			NavigationPage.SetHasNavigationBar(this, false);
		}
	}
}
