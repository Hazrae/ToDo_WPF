using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ToDo_WPF.Utils
{

	public class HttpController
	{
		private HttpClient _client;

		public HttpClient Client
		{
			get { return _client; }
			set { _client = value; }
		}


		public HttpController(string ui)
		{
			_client = new HttpClient();
			Client.BaseAddress = new Uri(ui);
		}

	}
}
