using System.Collections.Generic;
using System.Threading.Tasks;
using PaymillWrapper.Models;
using PaymillWrapper.Net;

namespace PaymillWrapper.Service
{
    public class RefundService : AbstractService<Refund>
    {
        public RefundService(HttpClientRest client, string apiUrl)
            : base(client, apiUrl)
        {
        }

        /// <summary>
        /// This function allows request a refund list
        /// </summary>
        /// <returns>Returns a list refunds-object</returns>
        public async Task<List<Refund>> GetRefundsAsync()
        {
            return await GetListAsync(Resource.Refunds);
        }

        /// <summary>
        /// This function allows request a refund list
        /// </summary>
        /// <param name="filter">Result filtered in the required way</param>
        /// <returns>Returns a list refund-object</returns>
        public async Task<List<Refund>> GetRefundsAsync(Filter filter)
        {
            return await GetListAsync(Resource.Refunds, filter);
        }

        /// <summary>
        /// This function creates a refund object
        /// </summary>
        /// <param name="refund">Object-refund</param>
        /// <returns>New object-refund just add</returns>
        public async Task<Refund> AddRefundAsync(Refund refund)
        {
            return await AddAsync(
                Resource.Refunds,
                refund,
                refund.Transaction.Id,
                new URLEncoder().EncodeRefund(refund));
        }

        /// <summary>
        /// To GetAsync the details of an object refund you’ll need to supply the refund ID
        /// </summary>
        /// <param name="refundID">Refund identifier</param>
        /// <returns>Refund-object</returns>
        public async Task<Refund> GetRefundAsync(string refundID)
        {
            return await GetAsync(Resource.Refunds, refundID);
        }
    }
}