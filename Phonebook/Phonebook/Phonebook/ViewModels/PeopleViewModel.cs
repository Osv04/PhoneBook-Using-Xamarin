using Phonebook.Models;
using Phonebook.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Phonebook.ViewModels
{
	class PeopleViewModel : BaseViewModel
	{
        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand AddCommand { get; set; }

        public ObservableCollection<People> ContactsList { get; set; } = new ObservableCollection<People>();
        People _selected;
        public People Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
                if (_selected != null)
                    DisplayElementSelect();
            }
        }

        public PeopleViewModel(ObservableCollection<People> contacts)
        {
            AddCommand = new Command(async (_selected) =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new AddPage(ContactsList));
            });

            DeleteCommand = new Command<People>(async (_selected) => {
                if (ContactsList.Remove(_selected))
                    await App.Current.MainPage.DisplayAlert("Deleted", "Se ha borrado un contacto", "OK");
            });

            EditCommand = new Command<People>(async (_selected) => {
                ContactsList.Remove(_selected);
                await App.Current.MainPage.Navigation.PushAsync(new AddPage(ContactsList, _selected));
            });
        }

        public async void DisplayElementSelect()
        {
            string Action, Title = "Choose", Cancel = "Cancel", But1 = $"Edit", But2 = $"Call {Selected.Number}";
            Action = await App.Current.MainPage.DisplayActionSheet($"{Title}", "", $"{Cancel}", $"{But1}", $"{But2}");

            if (Action == But1)
            {
                ContactsList.Remove(_selected);
                await App.Current.MainPage.Navigation.PushAsync(new AddPage(ContactsList, _selected));
            }
            else if (Action == But2)
            {
                PlacePhoneCall(_selected.Number);
            }
            else
            {
                return;
            }
        }

        public void PlacePhoneCall(string number)
        {
            try
            {
                PhoneDialer.Open(number);
            }
            catch (ArgumentNullException anEx)
            {
                // Number was null or white space
            }
            catch (FeatureNotSupportedException ex)
            {
                // Phone Dialer is not supported on this device.
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
        }
    }
}
