using Phonebook.Models;
using Phonebook.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Phonebook.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PeoplePage : ContentPage
	{
		public PeoplePage(ObservableCollection<People> contactsList)
		{
			InitializeComponent();
			BindingContext = new PeopleViewModel(contactsList);
		}
	}
}