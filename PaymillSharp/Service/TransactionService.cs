using System.Net.Http;
using PaymillSharp.Internal;
using PaymillSharp.Models;

namespace PaymillSharp.Service
{
    class TransactionService : AbstractService<Transaction>
    {
        public TransactionService(HttpClient client, string apiUrl)
            : base(Resource.Transactions, client, apiUrl)
        {
        }

        protected override string GetResourceId(Transaction obj)
        {
            return obj.Id;
        }

        protected override string GetEncodedCreateParams(Transaction obj, UrlEncoder encoder)
        {
            return encoder.EncodeTransaction(obj);
        }

        protected override string GetEncodedUpdateParams(Transaction obj, UrlEncoder encoder)
        {
            throw new System.NotImplementedException();
        }
    }
}