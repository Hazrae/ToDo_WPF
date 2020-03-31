using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ToDo_WPF.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void  RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(property)));
        }
    }
}
