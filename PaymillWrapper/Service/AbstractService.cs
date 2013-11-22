using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PaymillWrapper.Internal;
using PaymillWrapper.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using PaymillWrapper.Query;

namespace PaymillWrapper.Service
{
    abstract class AbstractService<T> : ICRUDService<T> 
        where T : BaseModel
    {
        private readonly Resource _resource;
        protected readonly HttpClient Client;
        private readonly string _apiUrl;

        protected AbstractService(Resource resource, 
            HttpClient client, 
            string apiUrl)
        {
            _resource = resource;
            Client = client;
            _apiUrl = apiUrl;
        }

        protected abstract string GetResourceId(T obj);
        protected abstract string GetEncodedCreateParams(T obj, UrlEncoder encoder);
        protected abstract string GetEncodedUpdateParams(T obj, UrlEncoder encoder);

        internal async Task<IResultCollection<T>> GetAsync(Query<T> query)
        {
            var requestUri = _apiUrl + "/" + _resource.ToString().ToLower();

            if (query != null)
                requestUri += String.Format("?{0}", query);

            var response = await Client.GetAsync(requestUri);
#if DEBUG
            Trace.WriteLine(requestUri);
            Trace.Write(await response.Content.ReadAsStringAsync());
#endif
            var json = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<MultipleResults<T>>(json, new UnixTimestampConverter());
            return new ResultCollection<T>(results.Data, query, results.Count);
        }

        public virtual async Task<IReadOnlyCollection<T>> GetAsync()
        {
            return await GetAsync(query: null);
        }

        public Query<T> Query
        {
            get { return new Query<T>(this); }
        }

        /// <summary>
        /// Adds an "item". Use this call if the result returns a different class than you send in.
        /// </summary>
        /// <typeparam name="TResult">The resulting type.</typeparam>
        protected async Task<TResult> AddAsync<TResult>(T obj)
        {
            var content = new StringContent(GetEncodedCreateParams(obj, new UrlEncoder()));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

            var requestUri = _apiUrl + "/" + _resource.ToString().ToLower();

            var resourceId = GetResourceId(obj);
            if (!string.IsNullOrEmpty(resourceId))
                requestUri += "/" + resourceId;

            var response = await Client.PostAsync(requestUri, content);

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<SingleResult<TResult>>(json, new UnixTimestampConverter());
            return result.Data;
        }

        /// <summary>
        /// Adds an "item".
        /// </summary>
        public virtual async Task<T> AddAsync(T obj)
        {
            return await AddAsync<T>(obj);
        }

        public virtual async Task<T> GetAsync(string resourceId)
        {
            var requestUri = _apiUrl + "/" + _resource.ToString().ToLower() + "/" + resourceId;
            var response = await Client.GetAsync(requestUri);
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<SingleResult<T>>(json, new UnixTimestampConverter());
            return result.Data;
        }

        public virtual async Task<bool> RemoveAsync(string resourceId)
        {
            var requestUri = _apiUrl + "/" + _resource.ToString().ToLower() + "/" + resourceId;
            var response = await Client.DeleteAsync(requestUri);
            var jsonArray = await response.Content.ReadAsAsync<JObject>();
            var r = jsonArray["data"].ToString();
            return r.Equals("[]");
        }

        public virtual async Task<T> UpdateAsync(T obj)
        {
            var content = new StringContent(GetEncodedUpdateParams(obj, new UrlEncoder()));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

            var requestUri = _apiUrl + "/" + _resource.ToString().ToLower() + "/" + GetResourceId(obj);
            var response = await Client.PutAsync(requestUri, content);
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<SingleResult<T>>(json, new UnixTimestampConverter());
            return result.Data;
        }
    }
}