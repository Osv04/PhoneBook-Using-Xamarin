using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Phonebook.ViewModels
{
	class BaseViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
	}
}
