using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using PaymillWrapper.Models;
using PaymillWrapper.Net;

namespace PaymillWrapper.Service
{
    public class PreauthorizationService : AbstractService<Preauthorization>
    {
        public PreauthorizationService(HttpClient client, string apiUrl)
            : base(client, apiUrl)
        {
        }

        /// <summary>
        /// This function allows request a preauthorization list
        /// </summary>
        /// <returns>Returns a list preauthorizations-object</returns>
        public async Task<List<Preauthorization>> GetPreauthorizationsAsync()
        {
            return await GetListAsync(Resource.Preauthorizations);
        }

        /// <summary>
        /// This function allows request a preauthorization list
        /// </summary>
        /// <param name="filter">Result filtered in the required way</param>
        /// <returns>Returns a list preauthorization-object</returns>
        public async Task<List<Preauthorization>> GetPreauthorizationsAsync(Filter filter)
        {
            return await GetListAsync(Resource.Preauthorizations, filter);
        }

        /// <summary>
        /// This function creates a transaction object
        /// </summary>
        /// <param name="preauthorization">Object-transaction</param>
        /// <returns>New object-transaction just add</returns>
        public async Task<Preauthorization> AddPreauthorizationAsync(Preauthorization preauthorization)
        {
            Preauthorization reply=null;

            var replyTransaction = await AddAsync<Transaction>(
                Resource.Preauthorizations,
                preauthorization,
                null,
                new UrlEncoder().EncodePreauthorization(preauthorization));

            if (replyTransaction != null)
                reply = replyTransaction.Preauthorization;

            return reply;
        }

        /// <summary>
        /// To GetAsync the details of an existing preauthorization you’ll need to supply the transaction ID
        /// </summary>
        /// <param name="preauthorizationId">Preauthorization identifier</param>
        /// <returns>Preauthorization-object</returns>
        public async Task<Preauthorization> GetPreauthorizationAsync(string preauthorizationId)
        {
            return await GetAsync(Resource.Preauthorizations, preauthorizationId);
        }
    }
}