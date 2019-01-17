using Everything.NET.Library.RawTypes.Queries;
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

        public List<Resource> Get(RawBaseQuery param)
        {
            return GetAsync(param).Result;
        }

        public async Task<List<Resource>> GetAsync(RawBaseQuery param)
        {
            var uri = new UriBuilder(http.BaseAddress)
            {
                Query = param.ToString()
            };

            var get = await http.GetAsync(uri.ToString());
            var json = await get.Content.ReadAsStringAsync();
            var raw = Json.ToObject<RawResults>(json);
            return Resource.FromRawResults(raw);
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
