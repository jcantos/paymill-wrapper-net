using System.Net.Http;
using PaymillWrapper.Models;
using PaymillWrapper.Net;

namespace PaymillWrapper.Service
{
    class TransactionService : AbstractService<Transaction>, ICRService<Transaction>
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