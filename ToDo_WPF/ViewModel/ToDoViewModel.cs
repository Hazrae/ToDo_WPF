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

        

    }
}
