using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Everything.NET.Library
{
    public class Request: IDisposable
    {
        private HttpClient http;

        public Request(Uri uri)
        {
            http = new HttpClient
            {
                BaseAddress = uri
            };
        }

        public Request(string server) : this(new Uri(server)) { }

        public void Dispose()
        {
            http.Dispose();
        }

        public Results Get(RequestParameter param)
        {
            return GetAsync(param).Result;
        }

        public async Task<Results> GetAsync(RequestParameter param)
        {
            var uri = new UriBuilder(http.BaseAddress)
            {
                Query = param.ToString()
            };

            var get = await http.GetAsync(uri.ToString());
            var json = await get.Content.ReadAsStringAsync();

            return Json.ToObject<Results>(json);
        }
    }
}
