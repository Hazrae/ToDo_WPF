using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ToDo_WPF.Utils
{
    public class APIConsume
    {
        private static APIConsume _instance;

        public static APIConsume Instance
        {
            get
            {
                _instance = _instance ?? new APIConsume();
                return _instance; 
            }
           
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

        public T Get<T>(string ui, string action, int? id = null)
        {
            HttpController http = new HttpController(ui);

            HttpResponseMessage message = http.Client.GetAsync(action + id).Result;
            message.EnsureSuccessStatusCode();
            string json = message.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<T>(json);
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
