using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_DAL.Models
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
