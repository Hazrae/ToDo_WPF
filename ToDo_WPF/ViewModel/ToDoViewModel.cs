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
    public class ToDoViewModel : ViewModelBase
    {
        private ToDo _entity;

        private DateTime? _validationDate;
        public DateTime? ValidationDate
        {
            get { return _validationDate; }
            set
            {
                if (_validationDate != value)
                {
                    _validationDate = value;
                    RaisePropertyChanged(nameof(ValidationDate));
                }
            }
        }

        private bool _state;

        public bool State
        {
            get { return _state; }
            set 
            {
                if (_state != value)
                {
                    _state = value;
                    RaisePropertyChanged(nameof(State));
                }
            }
        }

        private string _descr;
        public string Descr
        {
            get 
            { 
                return _descr; 
            }
            set
            {
                if (_descr != value)
                {
                    _descr = value;
                    RaisePropertyChanged(nameof(Descr));
                }
            }
        }

        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                if (_title != value)
                {
                    _title = value;
                    RaisePropertyChanged(nameof(Title));
                }
            }
        }             

        public ToDoViewModel(ToDo entity)
        {
            _entity = entity ?? throw new ArgumentNullException(nameof(entity));
            Title = entity.Title;
            Descr = entity.Descr;
            State = entity.State;
            ValidationDate = entity.ValidationDate;
        }

        public void Post<T>(string ui, string action, T item)
        {
            HttpController http = new HttpController(ui);

            string json = JsonConvert.SerializeObject(item);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            using (HttpResponseMessage message = http.Client.PostAsync(action, content).Result)
            {
                message.EnsureSuccessStatusCode();
                if (!message.IsSuccessStatusCode) { throw new HttpRequestException(); }
            }
        }

        public void Delete(string ui, string action, int id)
        {
            HttpController http = new HttpController(ui);

            HttpResponseMessage message = http.Client.DeleteAsync(action + id).Result;
            message.EnsureSuccessStatusCode();
        }

        public void Put<T>(string ui, string action, T item)
        {
            HttpController http = new HttpController(ui);
            string json = JsonConvert.SerializeObject(item);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            using (HttpResponseMessage message = http.Client.PutAsync(action, content).Result)
            {
                message.EnsureSuccessStatusCode();
                if (!message.IsSuccessStatusCode) { throw new HttpRequestException(); }
            }
        }

    }
}
