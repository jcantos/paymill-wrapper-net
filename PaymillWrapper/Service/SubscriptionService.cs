using System.Collections.Generic;
using System.Threading.Tasks;
using PaymillWrapper.Models;
using PaymillWrapper.Net;

namespace PaymillWrapper.Service
{
    public class SubscriptionService : AbstractService<Subscription>
    {
        public SubscriptionService(HttpClientRest client, string apiUrl)
            : base(client, apiUrl)
        {
        }

        /// <summary>
        /// This function allows request a subscription list
        /// </summary>
        /// <returns>Returns a list subscriptions-object</returns>
        public async Task<List<Subscription>> GetSubscriptionsAsync()
        {
            return await GetListAsync(Resource.Subscriptions);
        }

        /// <summary>
        /// This function allows request a subscription list
        /// </summary>
        /// <param name="filter">Result filtered in the required way</param>
        /// <returns>Returns a list subscription-object</returns>
        public async Task<List<Subscription>> GetSubscriptionsAsync(Filter filter)
        {
            return await GetListAsync(Resource.Subscriptions, filter);
        }

        /// <summary>
        /// This function creates a subscription object
        /// </summary>
        /// <param name="subscription">Object-subscription</param>
        /// <returns>New object-subscription just add</returns>
        public async Task<Subscription> AddSubscriptionAsync(Subscription subscription)
        {
            return await AddAsync(
                Resource.Subscriptions,
                subscription,
                null,
                new URLEncoder().EncodeSubscriptionAdd(subscription));
        }

        /// <summary>
        /// To GetAsync the details of an existing subscription you’ll need to supply the subscription ID
        /// </summary>
        /// <param name="subscriptionID">Subscription identifier</param>
        /// <returns>Subscription-object</returns>
        public async Task<Subscription> GetSubscriptionAsync(string subscriptionID)
        {
            return await GetAsync(Resource.Subscriptions, subscriptionID);
        }

        /// <summary>
        /// This function deletes a subscription
        /// </summary>
        /// <param name="subscriptionID">Subscription identifier</param>
        /// <returns>Return true if remove was ok, false if not possible</returns>
        public async Task<bool> RemoveSubscriptionAsync(string subscriptionID)
        {
            return await RemoveAsync(Resource.Subscriptions, subscriptionID);
        }

        /// <summary>
        /// This function updates the data of a subscription
        /// </summary>
        /// <param name="subscription">Object-subscription</param>
        /// <returns>Object-subscription just updated</returns>
        public async Task<Subscription> UpdateSubscriptionAsync(Subscription subscription)
        {
            return await UpdateAsync(
                Resource.Subscriptions,
                subscription,
                subscription.Id,
                new URLEncoder().EncodeSubscriptionUpdate(subscription));
        }
    }
}