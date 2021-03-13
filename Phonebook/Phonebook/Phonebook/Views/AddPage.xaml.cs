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
	public partial class AddPage : ContentPage
	{
		public AddPage(ObservableCollection<People> contactsList)
		{
			InitializeComponent();
			BindingContext = new AddViewModel(contactsList);
		}

		public AddPage(ObservableCollection<People> contactsList, People selected)
		{
			InitializeComponent();
			BindingContext = new AddViewModel(contactsList, selected);
		}
	}
}