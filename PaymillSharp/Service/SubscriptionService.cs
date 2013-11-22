using System.Net.Http;
using PaymillSharp.Internal;
using PaymillSharp.Models;

namespace PaymillSharp.Service
{
    class SubscriptionService : AbstractService<Subscription>
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