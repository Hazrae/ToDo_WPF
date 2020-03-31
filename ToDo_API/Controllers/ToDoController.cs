using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToDo_DAL.Models;
using ToDo_DAL.Services;


namespace ToDo_API.Controllers
{
    public class ToDoController : ApiController
    {
        private static ToDoController _instance;

        public static ToDoController Instance
        {
            get 
            {
                _instance = _instance ?? new ToDoController();
                return _instance;
            }
        }

        [Route("api/ToDo/")]
        public List<ToDo> GetAll()
        {
            return ToDoServices.Instance.GetAll();
        }

        [Route("api/ToDo/{id:int}")]
        public ToDo GetOne(int id)
        {
            return ToDoServices.Instance.GetOne(id);
        }

        [HttpPost]
        [Route("api/ToDo/")]
        public void Post(ToDo t)
        {
            ToDoServices.Instance.Create(t);
        }

        [HttpPut]
        [Route("api/ToDo/")]
        public void Put(ToDo t)
        {
            ToDoServices.Instance.Update(t);
        }

        [HttpPatch]
        [Route("api/ToDo/")]
        public void Patch(ToDo t)
        {
            ToDoServices.Instance.Update(t);
        }

        [HttpDelete]
        [Route("api/Film/{id:int}")]
        public void Delete(int id)
        {
            ToDoServices.Instance.Delete(id);
        }

    }
}
