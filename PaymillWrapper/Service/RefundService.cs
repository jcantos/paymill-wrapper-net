using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using PaymillWrapper.Models;
using PaymillWrapper.Net;

namespace PaymillWrapper.Service
{
    public class RefundService : AbstractService<Refund>
    {
        public RefundService(HttpClient client, string apiUrl)
            : base(client, apiUrl)
        {
        }

        /// <summary>
        /// This function allows request a refund list
        /// </summary>
        /// <param name="filter">Result filtered in the required way</param>
        /// <returns>Returns a list refund-object</returns>
        public async Task<IReadOnlyCollection<Refund>> GetAsync(Filter filter = null)
        {
            return await GetAsync(Resource.Refunds, filter);
        }

        /// <summary>
        /// This function creates a refund object
        /// </summary>
        /// <param name="refund">Object-refund</param>
        /// <returns>New object-refund just add</returns>
        public async Task<Refund> AddAsync(Refund refund)
        {
            return await AddAsync(
                Resource.Refunds,
                refund,
                refund.Transaction.Id,
                new UrlEncoder().EncodeRefund(refund));
        }

        /// <summary>
        /// To GetAsync the details of an object refund you’ll need to supply the refund ID
        /// </summary>
        /// <param name="refundId">Refund identifier</param>
        /// <returns>Refund-object</returns>
        public async Task<Refund> GetAsync(string refundId)
        {
            return await GetAsync(Resource.Refunds, refundId);
        }
    }
}