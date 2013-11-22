using System.Net.Http;
using PaymillSharp.Internal;
using PaymillSharp.Models;

namespace PaymillSharp.Service
{
    class OfferService : AbstractService<Offer>
    {
        public OfferService(HttpClient client, string apiUrl)
            : base(Resource.Offers, client, apiUrl)
        {
        }

        protected override string GetResourceId(Offer obj)
        {
            return obj.Id;
        }

        protected override string GetEncodedCreateParams(Offer obj, UrlEncoder encoder)
        {
            return encoder.EncodeOfferAdd(obj);
        }

        protected override string GetEncodedUpdateParams(Offer obj, UrlEncoder encoder)
        {
            return encoder.EncodeOfferUpdate(obj);
        }
    }
}