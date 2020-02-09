using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace kNN_UI
{
   public  class APIHelper
    {
        public HttpClient client { get; set; }
        public string route { get; set; }

        public APIHelper(string uri, string route)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(uri);
            this.route = route;

        }
        public HttpResponseMessage GetResponse(string parametar = "")
        {
            return client.GetAsync(route + "/" + parametar).Result;
        }
        public HttpResponseMessage GetResponsee(int parametar)
        {
            return client.GetAsync(route + "/" + parametar).Result;
        }
        //api/Korisnici/{username}
        public HttpResponseMessage GetActionResponse(string action, string parametar = "")
        {
            return client.GetAsync(route + "/" + action + "/" + parametar).Result;
        }

        public async Task<HttpResponseMessage> GetActionResponseAsync(string action, object parametar = null)
        {
            if (parametar != null)
                return await client.GetAsync(route + "/" + action + "/" + parametar.ToString());

            return await client.GetAsync(route + "/" + action);
        }

        public HttpResponseMessage GetResponseA(string action)
        {
            return client.GetAsync(route + "/" + action).Result;
        }
        //api/Korisnici/action
        public HttpResponseMessage GetResponseAction(string action)
        {
            return client.GetAsync(route + "/" + action).Result;
        }

        public HttpResponseMessage GetActionResponse(string action, int parametar)
        {
            return client.GetAsync(route + "/" + action + "/" + parametar).Result;
        }
    }
}
