using System.Net.Http;
using System;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using PaymillSharp.Models;
using PaymillSharp.Service;

[assembly: InternalsVisibleTo("UnitTest")]

namespace PaymillSharp
{
    public class Paymill
    {
        public Paymill(string apiKey, string apiUrl = "https://api.paymill.com/v2")
        {
            ApiKey = apiKey;
            ApiUrl = apiUrl;

            if (string.IsNullOrEmpty(ApiKey))
                throw new ArgumentException("You need to set an API key", "apiKey");

            if (string.IsNullOrEmpty(ApiUrl))
                throw new ArgumentException("You need to set an API URL.", "apiUrl");

            _clients = new Lazy<AbstractService<Client>>(() => new ClientService(Client, ApiUrl));
            _offers = new Lazy<AbstractService<Offer>>(() => new OfferService(Client, ApiUrl));
            _payments = new Lazy<AbstractService<Payment>>(() => new PaymentService(Client, ApiUrl));
            _preauthorizations = new Lazy<AbstractService<Preauthorization>>(() => new PreauthorizationService(Client, ApiUrl));
            _refunds = new Lazy<AbstractService<Refund>>(() => new RefundService(Client, ApiUrl));
            _subscriptions = new Lazy<AbstractService<Subscription>>(() => new SubscriptionService(Client, ApiUrl));
            _transactions = new Lazy<AbstractService<Transaction>>(() => new TransactionService(Client, ApiUrl));
        }

        public string ApiKey { get; private set; }
        public string ApiUrl { get; private set; }
        private HttpClient _httpClient;
        protected HttpClient Client
        {
            get
            {
                if (_httpClient == null)
                {
                    _httpClient = new HttpClient();
                    _httpClient.DefaultRequestHeaders.Accept
                        .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var authInfo = ApiKey + ":";
                    authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authInfo);  
                }
                
                return _httpClient;
            }
        }

        #region Service members
        private readonly Lazy<AbstractService<Client>> _clients;
        private readonly Lazy<AbstractService<Offer>> _offers;
        private readonly Lazy<AbstractService<Payment>> _payments;
        private readonly Lazy<AbstractService<Preauthorization>> _preauthorizations;
        private readonly Lazy<AbstractService<Refund>> _refunds;
        private readonly Lazy<AbstractService<Subscription>> _subscriptions;
        private readonly Lazy<AbstractService<Transaction>> _transactions;
        #endregion

        #region Public services
        public ICRUDService<Client> Clients
        {
            get { return _clients.Value; }
        }

        public ICRUDService<Offer> Offers
        {
            get { return _offers.Value; }
        }

        public ICRDService<Payment> Payments
        {
            get { return _payments.Value; }
        }

        public ICRService<Preauthorization> Preauthorizations
        {
            get { return _preauthorizations.Value; }
        }

        public ICRService<Refund> Refunds
        {
            get { return _refunds.Value; }
        }

        public ICRUDService<Subscription> Subscriptions
        {
            get { return _subscriptions.Value; }
        }

        public ICRService<Transaction> Transactions
        {
            get { return _transactions.Value; }
        }
        #endregion
    }
}