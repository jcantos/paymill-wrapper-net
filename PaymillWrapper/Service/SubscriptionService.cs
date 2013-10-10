using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using PaymillWrapper.Models;
using PaymillWrapper.Net;

namespace PaymillWrapper.Service
{
    public class SubscriptionService : AbstractService<Subscription>
    {
        public SubscriptionService(HttpClient client, string apiUrl)
            : base(client, apiUrl)
        {
        }

        /// <summary>
        /// This function allows request a subscription list
        /// </summary>
        /// <param name="filter">Result filtered in the required way</param>
        /// <returns>Returns a list subscription-object</returns>
        public async Task<IReadOnlyCollection<Subscription>> GetAsync(Filter filter = null)
        {
            return await GetAsync(Resource.Subscriptions, filter);
        }

        /// <summary>
        /// This function creates a subscription object
        /// </summary>
        /// <param name="subscription">Object-subscription</param>
        /// <returns>New object-subscription just add</returns>
        public async Task<Subscription> AddAsync(Subscription subscription)
        {
            return await AddAsync(
                Resource.Subscriptions,
                subscription,
                null,
                new UrlEncoder().EncodeSubscriptionAdd(subscription));
        }

        /// <summary>
        /// To GetAsync the details of an existing subscription you’ll need to supply the subscription ID
        /// </summary>
        /// <param name="subscriptionId">Subscription identifier</param>
        /// <returns>Subscription-object</returns>
        public async Task<Subscription> GetAsync(string subscriptionId)
        {
            return await GetAsync(Resource.Subscriptions, subscriptionId);
        }

        /// <summary>
        /// This function deletes a subscription
        /// </summary>
        /// <param name="subscriptionId">Subscription identifier</param>
        /// <returns>Return true if remove was ok, false if not possible</returns>
        public async Task<bool> RemoveAsync(string subscriptionId)
        {
            return await RemoveAsync(Resource.Subscriptions, subscriptionId);
        }

        /// <summary>
        /// This function updates the data of a subscription
        /// </summary>
        /// <param name="subscription">Object-subscription</param>
        /// <returns>Object-subscription just updated</returns>
        public async Task<Subscription> UpdateAsync(Subscription subscription)
        {
            return await UpdateAsync(
                Resource.Subscriptions,
                subscription,
                subscription.Id,
                new UrlEncoder().EncodeSubscriptionUpdate(subscription));
        }
    }
}