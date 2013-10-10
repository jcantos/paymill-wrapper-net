using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using PaymillWrapper.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace PaymillWrapper.Service
{
    public abstract class AbstractService<T>
    {
        protected readonly HttpClient Client;
        private readonly string _apiUrl;

        public enum Resource
        {
            Clients,
            Offers,
            Payments,
            Refunds,
            Subscriptions,
            Transactions,
            Preauthorizations
        }

        protected AbstractService(HttpClient client, string apiUrl)
        {
            Client = client;
            _apiUrl = apiUrl;
        }

        protected async Task<IReadOnlyCollection<T>> GetAsync(Resource resource, Filter filter = null)
        {
            var requestUri = _apiUrl + "/" + resource.ToString().ToLower();

            if (filter != null)
                requestUri += String.Format("?{0}", filter);

            var response = await Client.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();
            var jsonArray = await response.Content.ReadAsAsync<JObject>();
            return JsonConvert.DeserializeObject<ReadOnlyCollection<T>>(jsonArray["data"].ToString());
        }

        /// <summary>
        /// Adds an "item". Use this call if the result returns a different class than you send in.
        /// </summary>
        /// <typeparam name="TResult">The resulting type.</typeparam>
        protected async Task<TResult> AddAsync<TResult>(Resource resource, object obj, string resourceId, string encodeParams)
        {
            var content = new StringContent(encodeParams);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

            var requestUri = _apiUrl + "/" + resource.ToString().ToLower();

            if (!string.IsNullOrEmpty(resourceId))
                requestUri += "/" + resourceId;

            var response = await Client.PostAsync(requestUri, content);
            response.EnsureSuccessStatusCode();

            var jsonArray = await response.Content.ReadAsAsync<JObject>();
            return JsonConvert.DeserializeObject<TResult>(jsonArray["data"].ToString());
        }

        /// <summary>
        /// Adds an "item".
        /// </summary>
        protected async Task<T> AddAsync(Resource resource, object obj, string resourceId, string encodeParams)
        {
            return await AddAsync<T>(resource, obj, resourceId, encodeParams);
        }

        protected async Task<T> GetAsync(Resource resource, string resourceId)
        {
            var requestUri = _apiUrl + "/" + resource.ToString().ToLower() + "/" + resourceId;
            var response = await Client.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();
            var jsonArray = await response.Content.ReadAsAsync<JObject>();
            return JsonConvert.DeserializeObject<T>(jsonArray["data"].ToString());
        }

        protected async Task<bool> RemoveAsync(Resource resource, string resourceId)
        {
            var requestUri = _apiUrl + "/" + resource.ToString().ToLower() + "/" + resourceId;
            var response = await Client.DeleteAsync(requestUri);
            response.EnsureSuccessStatusCode();
            var jsonArray = await response.Content.ReadAsAsync<JObject>();
            var r = jsonArray["data"].ToString();
            return r.Equals("[]");
        }

        protected async Task<T> UpdateAsync(Resource resource, object obj, string resourceId, string encodeParams)
        {
            var content = new StringContent(encodeParams);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

            var requestUri = _apiUrl + "/" + resource.ToString().ToLower() + "/" + resourceId;
            var response = await Client.PutAsync(requestUri, content);
            response.EnsureSuccessStatusCode();
            var jsonArray = await response.Content.ReadAsAsync<JObject>();
            return JsonConvert.DeserializeObject<T>(jsonArray["data"].ToString());
        }
    }
}