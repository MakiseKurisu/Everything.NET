using System;
using System.Linq;
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
                BaseAddress =
                    new UriBuilder(uri)
                    {
                        Query = String.Empty
                    }.Uri
            };
        }

        public Request(string server) : this(new Uri(server)) { }

        public void Dispose()
        {
            http.Dispose();
        }

        public RawResults Get(RequestParameter param)
        {
            return GetAsync(param).Result;
        }

        public async Task<RawResults> GetAsync(RequestParameter param)
        {
            var uri = new UriBuilder(http.BaseAddress)
            {
                Query = param.ToString()
            };

            var get = await http.GetAsync(uri.ToString());
            var json = await get.Content.ReadAsStringAsync();

            return Json.ToObject<RawResults>(json);
        }

        public void LocateParent()
        {
            LocateChild("..");
        }

        public void LocateChild(String child)
        {
            http.BaseAddress = new Uri(http.BaseAddress, child);
        }
    }
}
