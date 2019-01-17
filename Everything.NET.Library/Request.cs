using Everything.NET.Library.RawTypes;
using Everything.NET.Library.Types.Queries;
using Everything.NET.Library.Types.Resources;
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

        public void Dispose()
        {
            http.Dispose();
        }

        public List<BaseResource> Get(BaseQuery param)
        {
            return GetAsync(param).Result;
        }

        public async Task<List<BaseResource>> GetAsync(BaseQuery param)
        {
            var uri = new UriBuilder(http.BaseAddress)
            {
                Query = param.ToString()
            };

            var get = await http.GetAsync(uri.ToString());

            var json = await get.Content.ReadAsStringAsync();

            var raw = Json.ToObject<RawQueryResult>(json);

            return BaseResource.FromRawQueryResult(uri.Uri, raw);
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
