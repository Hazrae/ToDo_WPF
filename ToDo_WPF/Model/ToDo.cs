using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo_WPF.Model
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Descr { get; set; }
        public bool State { get; set; }
        public DateTime? ValidationDate { get; set; }
    }
}
