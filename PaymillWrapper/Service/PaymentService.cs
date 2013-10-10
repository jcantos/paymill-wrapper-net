using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using PaymillWrapper.Models;
using PaymillWrapper.Net;

namespace PaymillWrapper.Service
{
    public class PaymentService : AbstractService<Payment>
    {
        public PaymentService(HttpClient client, string apiUrl)
            : base(client, apiUrl)
        {
        }

        /// <summary>
        /// This function allows request a payment list
        /// </summary>
        /// <param name="filter">Result filtered in the required way</param>
        /// <returns>Returns a list payments-object</returns>
        public async Task<IReadOnlyCollection<Payment>> GetAsync(Filter filter = null)
        {
            return await GetAsync(Resource.Payments, filter);
        }

        /// <summary>
        /// This function creates a payment object
        /// </summary>
        /// <param name="creditCardPayment">Object-payment</param>
        /// <returns>New object-payment just add</returns>
        public async Task<Payment> AddAsync(Payment creditCardPayment)
        {
            return await AddAsync(
                Resource.Payments,
                creditCardPayment,
                null,
                new UrlEncoder().Encode<Payment>(creditCardPayment));
        }

        /// <summary>
        /// To GetAsync the details of an existing payment you’ll need to supply the payment ID
        /// </summary>
        /// <param name="paymentId">Payment identifier</param>
        /// <returns>Payment-object</returns>
        public async Task<Payment> GetAsync(string paymentId)
        {
            return await GetAsync(Resource.Payments, paymentId);
        }

        /// <summary>
        /// This function deletes a payment
        /// </summary>
        /// <param name="paymentId">Payment identifier</param>
        /// <returns>Return true if remove was ok, false if not possible</returns>
        public async Task<bool> RemoveAsync(string paymentId)
        {
            return await RemoveAsync(Resource.Payments, paymentId);
        }

    }
}