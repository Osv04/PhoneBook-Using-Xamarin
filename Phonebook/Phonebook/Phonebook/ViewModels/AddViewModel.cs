using Phonebook.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Phonebook.ViewModels
{
	class AddViewModel : BaseViewModel
	{
		public ICommand ScanCommand { get; set; }
		public ICommand AddCommand { get; set; }
		public string PersonName { get; set; }
		public string PersonNumber { get; set; }

		People _addContact;
		public People NewContact
		{
			get
			{
				return _addContact;
			}
			set
			{
				_addContact = value;
				if (_addContact != null)
					return;
			}
		}

		public AddViewModel(ObservableCollection<People> contactsList)
		{
			AddCommand = new Command(async () =>
			{
				contactsList.Add(new People
				{
					Name = PersonName,
					Number = PersonNumber
				});
				await App.Current.MainPage.Navigation.PopAsync();
			});
		}

		public AddViewModel(ObservableCollection<People> people, People _selected)
		{
			PersonName = _selected.Name;
			PersonNumber = _selected.Number;
			AddCommand = new Command(async () => {
				people.Add(_selected);
				await App.Current.MainPage.Navigation.PopAsync();
			});
		}
	}
}
