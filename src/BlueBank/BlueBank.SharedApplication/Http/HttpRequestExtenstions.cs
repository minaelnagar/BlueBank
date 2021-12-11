using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;

namespace BlueBank.SharedApplication.Http
{
    public static class HttpRequestExtenstions
    {
        public static string BodyToString(this HttpRequest request)
        {
            if (request.Body.CanSeek && request.Body.Position != 0)
            {
                request.Body.Position = 0;
            }

            using (var sr = new StreamReader(request.Body))
            {
                return sr.ReadToEndAsync().Result;
            }
        }

        public static string AllHeadersToString(this IHeaderDictionary headers)
        {
            return string.Join(Environment.NewLine, headers.Keys.Select(k => $"{k}: {headers[k]}"));
        }
    }
}
