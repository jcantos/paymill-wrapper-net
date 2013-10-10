using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PaymillWrapper;
using PaymillWrapper.Models;
using PaymillWrapper.Net;

namespace PaymillWrapper.Service
{
    public class PaymentService : AbstractService<Payment>
    {
        public PaymentService(HttpClientRest client, string apiUrl)
            : base(client, apiUrl)
        {
        }

        /// <summary>
        /// This function allows request a payment list
        /// </summary>
        /// <returns>Returns a list payments-object</returns>
        public async Task<List<Payment>> GetPaymentsAsync()
        {
            return await GetListAsync(Resource.Payments);
        }

        /// <summary>
        /// This function allows request a payment list
        /// </summary>
        /// <param name="filter">Result filtered in the required way</param>
        /// <returns>Returns a list payments-object</returns>
        public async Task<List<Payment>> GetPaymentsAsync(Filter filter)
        {
            return await GetListAsync(Resource.Payments, filter);
        }

        /// <summary>
        /// This function creates a payment object
        /// </summary>
        /// <param name="client">Object-payment</param>
        /// <returns>New object-payment just add</returns>
        public async Task<Payment> AddPaymentAsync(Payment creditCardPayment)
        {
            return await AddAsync(
                Resource.Payments,
                creditCardPayment,
                null,
                new URLEncoder().Encode<Payment>(creditCardPayment));
        }

        /// <summary>
        /// To GetAsync the details of an existing payment you’ll need to supply the payment ID
        /// </summary>
        /// <param name="clientID">Payment identifier</param>
        /// <returns>Payment-object</returns>
        public async Task<Payment> GetPaymentAsync(string paymentID)
        {
            return await GetAsync(Resource.Payments, paymentID);
        }

        /// <summary>
        /// This function deletes a payment
        /// </summary>
        /// <param name="clientID">Payment identifier</param>
        /// <returns>Return true if remove was ok, false if not possible</returns>
        public async Task<bool> RemovePaymentAsync(string paymentID)
        {
            return await RemoveAsync(Resource.Payments, paymentID);
        }

    }
}