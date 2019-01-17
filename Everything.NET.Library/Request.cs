using Everything.NET.Library.RawTypes;
using Everything.NET.Library.Types.Queries;
using Everything.NET.Library.Types.Resources;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
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

            using (var token = new CancellationTokenSource())
            {
                var get = await http.GetAsync(uri.Uri, HttpCompletionOption.ResponseHeadersRead, token.Token);

                var ctype = get.Content.Headers.ContentType;
                var jsontype = new MediaTypeHeaderValue("application/json");
                if (param.json && !ctype.Equals(jsontype))
                {
                    token.Cancel();
                    throw new HttpRequestException($"HTTP returned unexpected ContentType {ctype}, expecting {jsontype}.");
                }

                var json = await get.Content.ReadAsStringAsync();

                var raw = Json.ToObject<RawQueryResult>(json);

                return BaseResource.FromRawQueryResult(uri.Uri, raw);
            }
        }

        public async Task<HttpResponseMessage> HeadAsync()
        {
            var uri = new UriBuilder(http.BaseAddress);

            var header = await http.SendAsync(new HttpRequestMessage(HttpMethod.Head, uri.Uri), HttpCompletionOption.ResponseHeadersRead);

            if (header.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                using (var token = new CancellationTokenSource())
                {
                    header = await http.GetAsync(uri.Uri, HttpCompletionOption.ResponseHeadersRead, token.Token);
                    token.Cancel();
                }
            }

            return header;
        }
    }
}
