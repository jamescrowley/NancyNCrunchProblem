using System.Collections.Generic;
using System.Net.Http;
using Machine.Specifications;
using Microsoft.Owin.Testing;

namespace NancyNCrunch
{
    public static class TestServerExtensions
    {
        public static AwaitResult<HttpResponseMessage> GetHtmlFromUrl(this TestServer server, string url, string authorization = null, string referer = null)
        {
            return GetUrl(server, url, authorization: authorization, referer: referer);
        }

        public static AwaitResult<HttpResponseMessage> GetJsonFromUrl(this TestServer server, string url, string authorization = null, string referer = null)
        {
            return GetUrl(server, url, "application/json", authorization, referer: referer);
        }

        public static AwaitResult<HttpResponseMessage> PostToJsonUrl(this TestServer server, string url, IDictionary<string, string> parameters, string authorization = null, string referer = null)
        {
            return PostUrl(server, url, parameters, "application/json", authorization, referer: referer);
        }

        public static AwaitResult<HttpResponseMessage> GetUrl(this TestServer server, string url, string contentType = null, string authorization = null, string referer = null)
        {
            return server.SendUrl(new HttpRequestMessage(HttpMethod.Get, url), contentType, authorization, referer);
        }

        public static AwaitResult<HttpResponseMessage> PostUrl(this TestServer server, string url, IDictionary<string, string> parameters, string contentType = null, string authorization = null, string referer = null)
        {
            var message = new HttpRequestMessage(HttpMethod.Post, url);
            message.Content = new FormUrlEncodedContent(parameters);
            return server.SendUrl(message, contentType, authorization, referer);
        }

        public static AwaitResult<HttpResponseMessage> SendUrl(this TestServer server, HttpRequestMessage message, string contentType = null, string authorization = null, string referer = null)
        {
            if (contentType != null)
            {
                message.Headers.Add("Accept", contentType);
            }
            if (authorization != null)
            {
                message.Headers.Add("Authorization", authorization);
            }
            if (referer != null)
            {
                message.Headers.Add("Referer", referer);
            }
            return server.HttpClient.SendAsync(message).Await();
        }
    }
}