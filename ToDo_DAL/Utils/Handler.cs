using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_DAL.Utils
{
    public static class Handler
    {
        private const string stringConnec = @"Data Source=KEVIN-PC\SQLServer;Initial Catalog=ToDoDB;Integrated Security=True";

        private static SqlConnection _connecDB;

        public static SqlConnection ConnecDB
        {
            get 
            { 
                _connecDB = _connecDB ?? new SqlConnection(stringConnec);
                return _connecDB;   
            }

        }

    }
}
