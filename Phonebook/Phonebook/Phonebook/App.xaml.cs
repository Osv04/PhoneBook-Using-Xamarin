using Phonebook.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Phonebook
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new PeoplePage(null));
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
