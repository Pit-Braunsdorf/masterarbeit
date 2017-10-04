using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Masterarbeit.Frontend.DatabaseAccess
{
    public class WebApiClient
    {
        private readonly string _baseAddress;

        public WebApiClient(string baseAddress)
        {
            _baseAddress = baseAddress;
        }

        public TResponse Get<TResponse>(string path)
        {
            return Get<TResponse>(path, null);
        }

        public TResponse Get<TResponse>(string path, IDictionary<string, object> urlParameters)
        {
            var query = BuildPathWithQuery(path, urlParameters);

            using (var requestMessage = CreateRequestMessage(HttpMethod.Get, query, null))
            {
                using (var responseMessage = SendRequestMessage(requestMessage))
                {
                    CheckResponseMessage(responseMessage);
                    return ParseResponseMessage<TResponse>(responseMessage);
                }
            }
        }

        public void Put(string path, object content)
        {
            Put(path, null, content);
        }

        public void Put(string path, IDictionary<string, object> urlParameters, object content)
        {
            var pathWithQuery = BuildPathWithQuery(path, urlParameters);
            using (var requestMessage = CreateRequestMessage(HttpMethod.Put, pathWithQuery, content))
            using (var responseMessage = SendRequestMessage(requestMessage))
            {
                CheckResponseMessage(responseMessage);
            }
        }

        public TResponse Post<TResponse>(string path, object content)
        {
            using (var requestMessage = CreateRequestMessage(HttpMethod.Post, path, content))
            using (var responseMessage = SendRequestMessage(requestMessage))
            {
                CheckResponseMessage(responseMessage);
                return ParseResponseMessage<TResponse>(responseMessage);
            }
        }

        public void Post(string path, object content)
        {
            Post(path, null, content);
        }

        public void Post(string path, IDictionary<string, object> urlParameters, object content)
        {
            var pathWithQuery = BuildPathWithQuery(path, urlParameters);
            using (var requestMessage = CreateRequestMessage(HttpMethod.Post, pathWithQuery, content))
            using (var responseMessage = SendRequestMessage(requestMessage))
            {
                CheckResponseMessage(responseMessage);
            }
        }

        public void Delete(string path, IDictionary<string, object> urlParameters)
        {
            var pathWithQuery = BuildPathWithQuery(path, urlParameters);
            using (var requestMessage = CreateRequestMessage(HttpMethod.Delete, pathWithQuery, null))
            using (var responseMessage = SendRequestMessage(requestMessage))
            {
                CheckResponseMessage(responseMessage);
            }
        }

        public void Delete(string path, object content)
        {
            using (var requestMessage = CreateRequestMessage(HttpMethod.Delete, path, content))
            using (var responseMessage = SendRequestMessage(requestMessage))
            {
                CheckResponseMessage(responseMessage);
            }
        }

        private static void CheckResponseMessage(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException($"Webservice meldet Status {response.StatusCode}");
            }
        }

        private HttpResponseMessage SendRequestMessage(HttpRequestMessage message)
        {
            using (var client = CreateHttpClient())
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                return client.SendAsync(message).Result;
            }
        }

        protected virtual HttpClient CreateHttpClient()
        {
            return new HttpClient(new HttpClientHandler()
            {
                // Redirect bedeutet wahrscheinlich Weiterleitung auf Nutzeranmeldeseite
                AllowAutoRedirect = false,
                UseCookies = false
            });
        }

        private static HttpRequestMessage CreateRequestMessage(HttpMethod method, string query, object content)
        {
            var message = new HttpRequestMessage(method, query);

            if (content != null)
            {
                var json = JsonConvert.SerializeObject(content);
                message.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }
            return message;
        }

        private static string BuildPathWithQuery(string path, IDictionary<string, object> urlParameters)
        {
            if (urlParameters != null)
            {
                var query = string.Join("&", urlParameters.Select(p => p.Value != null ? $"{p.Key}={Uri.EscapeUriString(p.Value.ToString())}" : p.Key));
                if (!string.IsNullOrEmpty(query))
                {
                    path += "?" + query;
                }
            }
            return path;
        }
        private static T ParseResponseMessage<T>(HttpResponseMessage response)
        {
            var content = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
