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
    public static class Request
    {
        private static HttpClient http;
        private static SemaphoreSlim semaphore;

        static Request()
        {
            http = new HttpClient();
            semaphore = new SemaphoreSlim(Environment.ProcessorCount);
            Console.WriteLine($"{semaphore} created with{Environment.ProcessorCount} count");
        }

        public static void GetLock()
        {
            semaphore.Wait();
        }

        public static int ReleaseLock()
        {
            return semaphore.Release();
        }

        public static List<BaseResource> Get(Uri u, BaseQuery param)
        {
            return GetAsync(u, param).Result;
        }

        public static async Task<List<BaseResource>> GetAsync(Uri uri, BaseQuery param)
        {
            uri = new UriBuilder(uri)
            {
                Query = param.ToString()
            }.Uri;

            using (var token = new CancellationTokenSource())
            {
                var get = await http.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead, token.Token);

                var ctype = get.Content.Headers.ContentType;
                var jsontype = new MediaTypeHeaderValue("application/json");
                if (param.json && !ctype.Equals(jsontype))
                {
                    token.Cancel();
                    throw new HttpRequestException($"HTTP returned unexpected ContentType {ctype}, expecting {jsontype}.");
                }

                var json = await get.Content.ReadAsStringAsync();

                var raw = Json.ToObject<RawQueryResult>(json);

                return BaseResource.FromRawQueryResult(uri, raw);
            }
        }

        public static async Task<HttpResponseMessage> HeadAsync(Uri uri)
        {
            uri = new UriBuilder(uri)
            {
                Query = String.Empty
            }.Uri;

            var header = await http.SendAsync(new HttpRequestMessage(HttpMethod.Head, uri), HttpCompletionOption.ResponseHeadersRead);

            if (header.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                using (var token = new CancellationTokenSource())
                {
                    header = await http.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead, token.Token);
                    token.Cancel();
                }
            }

            return header;
        }
    }
}
