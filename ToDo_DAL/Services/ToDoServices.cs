using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_DAL.Models;
using ToDo_DAL.Repositories;
using ToDo_DAL.Utils;

namespace ToDo_DAL.Services
{
    public class ToDoServices : IRepository<ToDo>
    {

        // Singleton instance ToDoService
        private static ToDoServices _instance;

        public static ToDoServices Instance
        {
            get 
            { 
                _instance = _instance ?? new ToDoServices();
                return _instance;  
            }

        }

        private ToDoServices()
        {

        }

        //Create via procédure stockée
        public void Create(ToDo t)
        {
            using (SqlCommand cmd = new SqlCommand("InsertToDo", Handler.ConnecDB))
            {

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("title", t.Title);
                cmd.Parameters.AddWithValue("descr", t.Descr);
                cmd.Parameters.AddWithValue("state", t.State);

                Handler.ConnecDB.Open();
                cmd.ExecuteNonQuery();
                Handler.ConnecDB.Close();

            }

        }

        //Delete via procédure stockée
        public void Delete(int id)
        {
            using (SqlCommand cmd = new SqlCommand("DeleteToDo", Handler.ConnecDB))
            {

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("id", id);

                Handler.ConnecDB.Open();
                cmd.ExecuteNonQuery();
                Handler.ConnecDB.Close();

            }
        }

        public List<ToDo> GetAll()
        {
            List<ToDo> list = new List<ToDo>();
            Handler.ConnecDB.Open();

            //creation de la cmd
            using (SqlCommand cmd = Handler.ConnecDB.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM ToDo";

                //execution
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    //creation de la liste en bouclant sur le DR
                    while (dr.Read())
                    {
                        DateTime? checkDate;
                        if (!(dr["ValidationDate"] is DBNull))
                            checkDate = Convert.ToDateTime(dr["validationDate"]);
                        else
                            checkDate = null;

                        list.Add(new ToDo
                        {
                            Id = (int)dr["id"],
                            Title = dr["title"].ToString(),
                            Descr = dr["descr"].ToString(),
                            State = (bool)dr["state"],
                            ValidationDate = checkDate,
                            //ValidationDate = (!(dr["ValidationDate"] is DBNull)) ? Convert.ToDateTime(dr["validationDate"]) : null

                        }); ; 
                    }
                }
            }
            Handler.ConnecDB.Close();
            return list;

        }

        public ToDo GetOne(int id)
        {
            Handler.ConnecDB.Open();
            ToDo todo = new ToDo();

            //creation de la cmd
            using (SqlCommand cmd = Handler.ConnecDB.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM ToDo WHERE id = @id";
                cmd.Parameters.AddWithValue("id", id);

                //exécution et boucle sur le DR pour garnir l'objet
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dr.Read();
                    todo.Id = (int)dr["id"];
                    todo.Title = dr["title"].ToString();
                    todo.Descr = dr["descr"].ToString();
                    todo.State = (bool)dr["state"];
                    if (!(dr["ValidationDate"] is DBNull))
                        todo.ValidationDate = Convert.ToDateTime(dr["validationDate"]);
                    else
                        todo.ValidationDate = null;
                }
            }
            Handler.ConnecDB.Close();
            return todo;
        }

        public void Update(ToDo t)
        {
            using (SqlCommand cmd = new SqlCommand("updateToDo", Handler.ConnecDB))
            {

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("id", t.Id);
                cmd.Parameters.AddWithValue("title", t.Title);
                cmd.Parameters.AddWithValue("descr", t.Descr);
                cmd.Parameters.AddWithValue("state", t.State);

                Handler.ConnecDB.Open();
                cmd.ExecuteNonQuery();
                Handler.ConnecDB.Close();

            }
        }
    }
}
