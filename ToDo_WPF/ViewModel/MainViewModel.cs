using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using ToDo_API.Controllers;
using ToDo_WPF.Model;
using ToDo_WPF.Utils;

namespace ToDo_WPF.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<ToDoViewModel> _items;
        public string Titre { get; set; }
        public string Des { get; set; }
        public bool Etat { get; set; }

        public ObservableCollection<ToDoViewModel> Items
        {
            get
            {
                return _items ??= LoadItems();
            }
            set
            {
                if(_items != value)
                {
                    _items = value;
                    RaisePropertyChanged(nameof(Items));
                }
            }
        }


        private ObservableCollection<ToDoViewModel> LoadItems()
        {

            return new ObservableCollection<ToDoViewModel>(APIConsume.Instance.Get<List<ToDo>>("https://localhost:44316/api/", "ToDo/").Select(td => new ToDoViewModel(td)));
        }

        private RelayCommand _ajoutCommand;

        public RelayCommand AjoutCommand
        {
            get { return _ajoutCommand ?? (_ajoutCommand = new RelayCommand(Ajout)); }

        }
                
        private void Ajout()
         {
            ToDo td = new ToDo
            {
                Title = Titre,
                Descr = Des,
                State = Etat,
            };

            APIConsume.Instance.Post<ToDo>("https://localhost:44316/api/", "ToDo/", td);
            Items = LoadItems();
            //RaisePropertyChanged(nameof(Items));
            //Items.Add(new ToDoViewModel(td));
        }        
       
    }
}
