using System.Net.Http;
using PaymillWrapper.Models;
using PaymillWrapper.Net;

namespace PaymillWrapper.Service
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