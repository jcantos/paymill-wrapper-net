using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using PaymillWrapper.Internal;
using PaymillWrapper.Models;

namespace PaymillWrapper.Service
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