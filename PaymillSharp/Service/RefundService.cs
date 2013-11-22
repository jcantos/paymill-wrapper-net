using System.Net.Http;
using PaymillSharp.Internal;
using PaymillSharp.Models;

namespace PaymillSharp.Service
{
    class RefundService : AbstractService<Refund>
    {
        public RefundService(HttpClient client, string apiUrl)
            : base(Resource.Refunds, client, apiUrl)
        {
        }

        protected override string GetResourceId(Refund obj)
        {
            return obj.Id;
        }

        protected override string GetEncodedCreateParams(Refund obj, UrlEncoder encoder)
        {
            return encoder.EncodeRefund(obj);
        }

        protected override string GetEncodedUpdateParams(Refund obj, UrlEncoder encoder)
        {
            throw new System.NotImplementedException();
        }
    }
}