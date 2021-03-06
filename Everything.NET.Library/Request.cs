﻿using Everything.NET.Library.RawTypes;
using Everything.NET.Library.Types.Queries;
using Everything.NET.Library.Types.Resources;
using System;
using System.Collections.Generic;
using System.IO;
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
        }

        public static Task GetLock()
        {
            return semaphore.WaitAsync();
        }

        public static int ReleaseLock()
        {
            return semaphore.Release();
        }

        public static async Task<Stream> Get(Uri uri, BaseQuery param)
        {
            uri = new UriBuilder(uri)
            {
                Query = param.ToString()
            }.Uri;

            using (var token = new CancellationTokenSource())
            {
                var get = await http.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead, token.Token);

                if (Option.no_mime_type_check == false)
                {
                    var ctype = get.Content.Headers.ContentType;
                    var jsontype = new MediaTypeHeaderValue("application/json");
                    if (param.json && !ctype.Equals(jsontype))
                    {
                        token.Cancel();
                        throw new HttpRequestException($"HTTP returned unexpected ContentType {ctype}, expecting {jsontype}.");
                    }
                }

                return await get.Content.ReadAsStreamAsync();
            }
        }

        public static async Task<HttpResponseMessage> Head(Uri uri)
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
