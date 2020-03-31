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

        public MainViewModel()
        {

        }

        public ObservableCollection<ToDoViewModel> Items
        {
            get
            {
                return _items ??= LoadItems();
            }
        }


        private ObservableCollection<ToDoViewModel> LoadItems()
        {

            return new ObservableCollection<ToDoViewModel>(Get<List<ToDo>>("https://localhost:44316/api/", "ToDo/").Select(td => new ToDoViewModel(td)));
        }

        public T Get<T>(string ui, string action, int? id = null)
        {
            HttpController http = new HttpController(ui);

            HttpResponseMessage message = http.Client.GetAsync(action + id).Result;
            message.EnsureSuccessStatusCode();
            string json = message.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<T>(json);
        }
       
    }
}
