using System.Net.Http;
using PaymillWrapper.Internal;
using PaymillWrapper.Models;

namespace PaymillWrapper.Service
{
    class SubscriptionService : AbstractService<Subscription>, ICRUDService<Subscription>
    {
        public SubscriptionService(HttpClient client, string apiUrl)
            : base(Resource.Subscriptions, client, apiUrl)
        {
        }

        protected override string GetResourceId(Subscription obj)
        {
            return obj.Id;
        }

        protected override string GetEncodedCreateParams(Subscription obj, UrlEncoder encoder)
        {
            return encoder.EncodeSubscriptionAdd(obj);
        }

        protected override string GetEncodedUpdateParams(Subscription obj, UrlEncoder encoder)
        {
            return encoder.EncodeSubscriptionUpdate(obj);
        }
    }
}