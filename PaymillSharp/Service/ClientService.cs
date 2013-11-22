using System.Net.Http;
using PaymillSharp.Internal;
using PaymillSharp.Models;

namespace PaymillSharp.Service
{
    class ClientService : AbstractService<Client>
    {
        public ClientService(HttpClient client, string apiUrl)
            : base(Resource.Clients, client, apiUrl)
        {
        }

        protected override string GetResourceId(Client obj)
        {
            return obj.Id;
        }

        protected override string GetEncodedCreateParams(Client obj, UrlEncoder encoder)
        {
            return encoder.Encode<Client>(obj);
        }

        protected override string GetEncodedUpdateParams(Client obj, UrlEncoder encoder)
        {
            return encoder.EncodeClientUpdate(obj);
        }
    }
}