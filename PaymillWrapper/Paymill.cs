using PaymillWrapper.Net;
using System;
using System.Net.Http.Headers;
using System.Text;
using PaymillWrapper.Service;

namespace PaymillWrapper
{
    public class Paymill
    {
        public Paymill(string apiKey, string apiUrl = "https://api.paymill.com/v2/")
        {
            ApiKey = apiKey;
            ApiUrl = apiUrl;

            if (string.IsNullOrEmpty(ApiKey))
                throw new ArgumentException("You need to set an API key", "apiKey");

            if (string.IsNullOrEmpty(ApiUrl))
                throw new ArgumentException("You need to set an API URL.", "apiUrl");
        }

        private ClientService _clients;
        private OfferService _offers;
        private PaymentService _payments;
        private PreauthorizationService _preauthorizations;
        private RefundService _refunds;
        private SubscriptionService _subscriptions;
        private TransactionService _transactions;
        public string ApiKey { get; private set; }
        public string ApiUrl { get; private set; }
        protected HttpClientRest Client
        {
            get
            {
                var client = new HttpClientRest(ApiUrl, ApiKey);
                client.DefaultRequestHeaders.Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var authInfo = ApiKey + ":";
                authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authInfo);  

                return client;
            }
        }

        public ClientService Clients
        {
            get { return _clients = _clients ?? new ClientService(Client, ApiUrl); }
        }

        public OfferService Offers
        {
            get { return _offers = _offers ?? new OfferService(Client, ApiUrl); }
        }

        public PaymentService Payments
        {
            get { return _payments = _payments ?? new PaymentService(Client, ApiUrl); }
        }

        public PreauthorizationService Preauthorizations
        {
            get { return _preauthorizations = _preauthorizations ?? new PreauthorizationService(Client, ApiUrl); }
        }

        public RefundService Refunds
        {
            get { return _refunds = _refunds ?? new RefundService(Client, ApiUrl); }
        }

        public SubscriptionService Subscriptions
        {
            get { return _subscriptions = _subscriptions ?? new SubscriptionService(Client, ApiUrl); }
        }

        public TransactionService Transactions
        {
            get { return _transactions = _transactions ?? new TransactionService(Client, ApiUrl); }
        }
    }
}