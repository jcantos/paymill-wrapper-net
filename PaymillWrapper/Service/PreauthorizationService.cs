using System;
using System.Net.Http;
using System.Threading.Tasks;
using PaymillWrapper.Models;
using PaymillWrapper.Net;

namespace PaymillWrapper.Service
{
    class PreauthorizationService : AbstractService<Preauthorization>
    {
        public PreauthorizationService(HttpClient client, string apiUrl) 
            : base(Resource.Preauthorizations, client, apiUrl)
        {
        }

        protected override string GetResourceId(Preauthorization obj)
        {
            return obj.Id;
        }

        protected override string GetEncodedCreateParams(Preauthorization obj, UrlEncoder encoder)
        {
            return encoder.EncodePreauthorization(obj);
        }

        protected override string GetEncodedUpdateParams(Preauthorization obj, UrlEncoder encoder)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This function creates a transaction object
        /// </summary>
        /// <param name="preauthorization">Object-transaction</param>
        /// <returns>New object-transaction just add</returns>
        public override async Task<Preauthorization> AddAsync(Preauthorization preauthorization)
        {
            Preauthorization reply=null;

            var replyTransaction = await AddAsync<Transaction>(preauthorization);

            if (replyTransaction != null)
                reply = replyTransaction.Preauthorization;

            return reply;
        }
    }
}