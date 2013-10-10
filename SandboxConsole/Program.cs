using System;
using System.Threading.Tasks;
using PaymillWrapper;
using PaymillWrapper.Models;
using PaymillWrapper.Net;

namespace SandboxConsole
{
    class Program
    {
        static void Main()
        {
            AsyncMain().Wait();

            Console.ReadLine();
        }

        static async Task AsyncMain()
        {
            await GetClientsWithParameters();
        }

        private static Paymill CreatePaymillInstance()
        {
            return new Paymill(Properties.Settings.Default.ApiKey, Properties.Settings.Default.ApiUrl);
        }

        // payments
        static async Task GetPayments()
        {
            // list payments
            Console.WriteLine("Waiting request list payments...");

            var lstPayments = await CreatePaymillInstance().Payments.GetPaymentsAsync();

            foreach (var payment in lstPayments)
            {
                Console.WriteLine("PaymentID:{0}", payment.Id); 
            }

            Console.Read();
        }
        static async Task GetPaymentsWithParameters()
        {
            // list payments
            Console.WriteLine("Waiting request list payments with parameters...");

            var filter = new Filter();
            filter.Add("count", 5);
            filter.Add("offset", 41);

            var lstPayments = await CreatePaymillInstance().Payments.GetPaymentsAsync(filter);

            foreach (var payment in lstPayments)
            {
                Console.WriteLine("PaymentID:{0}", payment.Id);
            }

            Console.Read();
        }
        static async Task AddCreditCardPayment()
        {
            var payment = new Payment {Token = "098f6bcd4621d373cade4e832627b4f6"};

            var newPayment = await CreatePaymillInstance().Payments.AddPaymentAsync(payment);

            Console.WriteLine("PaymentID:{0}", newPayment.Id);
            Console.Read();
        }
        static async Task AddCreditCardPaymentWithClient()
        {
            var payment = new Payment
            {
                Token = "098f6bcd4621d373cade4e832627b4f6",
                Client = "client_ad591663d69051d306a8"
            };

            var newPayment = await CreatePaymillInstance().Payments.AddPaymentAsync(payment);

            Console.WriteLine("PaymentID:{0}", newPayment.Id);
            Console.WriteLine("Created at:{0}", newPayment.CreatedAt);
            Console.Read();
        }
        static async Task AddDebitPayment()
        {
            var payment = new Payment
            {
                Type = Payment.TypePayment.Debit,
                Code = "86055500",
                Account = "1234512345",
                Holder = "Max Mustermann"
            };

            var newPayment = await CreatePaymillInstance().Payments.AddPaymentAsync(payment);

            Console.WriteLine("PaymentID:{0}", newPayment.Id);
            Console.WriteLine("Created at:{0}", newPayment.CreatedAt);
            Console.Read();
        }
        static async Task AddDebitPaymentWithClient()
        {
            var payment = new Payment
            {
                Type = Payment.TypePayment.Debit,
                Code = "86055500",
                Account = "1234512345",
                Holder = "Max Mustermann",
                Client = "client_bbe895116de80b6141fd"
            };

            var newPayment = await CreatePaymillInstance().Payments.AddPaymentAsync(payment);

            Console.WriteLine("PaymentID:{0}", newPayment.Id);
            Console.WriteLine("Created at:{0}", newPayment.CreatedAt);
            Console.Read();
        }
        static async Task GetPayment()
        {
            const string paymentId = "pay_4c159fe95d3be503778a";
            var payment = await CreatePaymillInstance().Payments.GetPaymentAsync(paymentId);

            Console.WriteLine("PaymentID:{0}", payment.Id);
            Console.WriteLine("PaymentID:{0}", payment.CreatedAt.ToShortDateString());
            Console.Read();
        }
        static async Task RemovePayment()
        {
            const string paymentId = "pay_640be2127169cea1d375";
            var reply = await CreatePaymillInstance().Payments.RemovePaymentAsync(paymentId);

            Console.WriteLine("Result remove:{0}", reply);
            Console.Read();
        }

        // transactions
        static async Task GetTransactions()
        {
            Console.WriteLine("Waiting request list transactions...");
            var lstTransactions = await CreatePaymillInstance().Transactions.GetTransactionsAsync();

            foreach (var transaction in lstTransactions)
            {
                Console.WriteLine("TransactionID:{0}", transaction.Id);
            }

            Console.Read();
        }
        static async Task GetTransactionsWithParameters()
        {
            Console.WriteLine("Waiting request list transactions with parameters...");

            var filter = new Filter();
            filter.Add("count", 1);
            filter.Add("offset", 2);

            var lstTransactions = await CreatePaymillInstance().Transactions.GetTransactionsAsync(filter);

            foreach (var transaction in lstTransactions)
            {
                Console.WriteLine("TransactionID:{0}", transaction.Id);
            }

            Console.Read();
        }
        static async Task AddTransaction()
        {
            var transaction = new Transaction
            {
                Token = "098f6bcd4621d373cade4e832627b4f6",
                Amount = 3500,
                Currency = "EUR",
                Description = "Prueba desde API c#"
            };

            var newTransaction = await CreatePaymillInstance().Transactions.AddTransactionAsync(transaction);

            Console.WriteLine("TransactionID:{0}", newTransaction.Id);
            Console.Read();
        }
        static async Task AddTransactionWithPayment()
        {
            var transaction = new Transaction
            {
                Amount = 3500,
                Currency = "EUR",
                Description = "Prueba desde API c#",
                Payment = new Payment {Id = "pay_81ec02206e9b9c587513"}
            };

            var newTransaction = await CreatePaymillInstance().Transactions.AddTransactionAsync(transaction);

            Console.WriteLine("TransactionID:{0}", newTransaction.Id);
            Console.Read();
        }
        static async Task AddTransactionWithClient()
        {
            // Hay que depurar esta función, no funciona bien cuando se pasa el identificador del cliente, 
            // está creando un nuevo cliente aunque le pasemos el identificador de uno ya existente

            var transaction = new Transaction
            {
                Amount = 8000,
                Currency = "EUR",
                Description = "Transacción con cliente",
                Payment = new Payment {Id = "pay_c08f1f94754b93f46ac3"},
                Client = new Client {Id = "client_ad591663d69051d306a8"}
            };

            var newTransaction = await CreatePaymillInstance().Transactions.AddTransactionAsync(transaction);

            Console.WriteLine("TransactionID:{0}", newTransaction.Id);
            Console.Read();
        }
        static async Task GetTransaction()
        {
            Console.WriteLine("Solicitando transaction...");
            const string transactionId = "tran_9255ee9ad5a7f2999625";
            var transaction = await CreatePaymillInstance().Transactions.GetTransactionAsync(transactionId);

            Console.WriteLine("TransactionID:{0}", transaction.Id);
            Console.WriteLine("Created at:{0}", transaction.CreatedAt.ToShortDateString());
            Console.Read();
        }

        // preauthorizations
        static async Task GetPreauthorizations()
        {
            Console.WriteLine("Waiting request list preauthorizations...");
            var lstPreauthorizations = await CreatePaymillInstance().Preauthorizations.GetPreauthorizationsAsync();

            foreach (var preauthorization in lstPreauthorizations)
            {
                Console.WriteLine("PreauthorizationID:{0}", preauthorization.Id);
            }

            Console.Read();
        }
        static async Task GetPreauthorizationsWithParameters()
        {
            Console.WriteLine("Waiting request list preauthorizations...");

            var filter = new Filter();
            filter.Add("count", 1);
            filter.Add("offset", 2);

            var lstPreauthorizations = await CreatePaymillInstance().Preauthorizations.GetPreauthorizationsAsync(filter);

            foreach (var preauthorization in lstPreauthorizations)
            {
                Console.WriteLine("PreauthorizationID:{0}", preauthorization.Id);
            }

            Console.Read();
        }
        static async Task AddPreauthorization()
        {
            var preauthorization = new Preauthorization
            {
                Amount = 3500,
                Currency = "EUR",
                Payment = new Payment {Id = "pay_4c159fe95d3be503778a"}
            };

            var newPreauthorization = await CreatePaymillInstance().Preauthorizations.AddPreauthorizationAsync(preauthorization);

            Console.WriteLine("PreauthorizationID:{0}", newPreauthorization.Id);
            Console.Read();
        }
        static async Task GetPreauthorization()
        {
            Console.WriteLine("Solicitando preauthorization...");
            const string preauthorizationId = "preauth_96fe414f466f91ddb266";
            var preauthorization = await CreatePaymillInstance().Preauthorizations.GetPreauthorizationAsync(preauthorizationId);

            Console.WriteLine("PreauthorizationID:{0}", preauthorization.Id);
            Console.WriteLine("Created at:{0}", preauthorization.CreatedAt.ToShortDateString());
            Console.Read();
        }

        // refunds
        static async Task GetRefunds()
        {
            Console.WriteLine("Waiting request list refunds...");
            var lstRefunds = await CreatePaymillInstance().Refunds.GetRefundsAsync();

            foreach (var refund in lstRefunds)
            {
                Console.WriteLine("RefundID:{0}", refund.Id);
            }

            Console.Read();
        }
        static async Task GetRefundsWithParameters()
        {
            // probar los parametros, no funciona bien
            // transaction es ok
            // client no funciona
            // amount es ok
            // created_at no funciona
            // count es ok

            Console.WriteLine("Waiting request list refunds with parameters...");

            var filter = new Filter();
            filter.Add("count", 5);

            var lstRefunds = await CreatePaymillInstance().Refunds.GetRefundsAsync(filter);

            foreach (var refund in lstRefunds)
            {
                Console.WriteLine("RefundID:{0}", refund.Id);
            }

            Console.Read();
        }
        static async Task AddRefund()
        {
            // la documentación de la API está mal, devuelve un objeto Refund en vez de Transaction

            var refund = new Refund
            {
                Amount = 500,
                Description = "Prueba desde API c#",
                Transaction = new Transaction {Id = "tran_a7c93a1e5b431b52c0f0"}
            };

            var newRefund = await CreatePaymillInstance().Refunds.AddRefundAsync(refund);

            Console.WriteLine("RefundID:{0}", newRefund.Id);
            Console.Read();
        }
        static async Task GetRefund()
        {
            Console.WriteLine("Request refund...");
            const string refundId = "refund_53860aa0e514d4913aad";
            var refund = await CreatePaymillInstance().Refunds.GetRefundAsync(refundId);

            Console.WriteLine("RefundID:{0}", refund.Id);
            Console.WriteLine("Created at:{0}", refund.CreatedAt.ToShortDateString());
            Console.Read();
        }

        // clients
        static async Task GetClients()
        {
            Console.WriteLine("Waiting request list clients...");
            var lstClients = await CreatePaymillInstance().Clients.GetClientsAsync();

            foreach (var c in lstClients)
            {
                Console.WriteLine("ClientID:{0}", c.Id);
            }

            Console.Read();
        }
        static async Task GetClientsWithParameters()
        {
            Console.WriteLine("Waiting request list clients with parameters...");

            var filter = new Filter();
            //filter.Add("email", "javicantos22@hotmail.es"); //OK
            //filter.Add("creditcard", "pay_f95c7d70c6ad8da339e5"); //KO
            filter.Add("created_at", 1352930695); //KO

            var lstClients = await CreatePaymillInstance().Clients.GetClientsAsync(filter);

            foreach (var c in lstClients)
            {
                Console.WriteLine("ClientID:{0}", c.Id);
            }

            Console.Read();
        }
        static async Task AddClient()
        {
            var c = new Client {Description = "Prueba API", Email = "javicantos22@hotmail.es"};

            var newClient = await CreatePaymillInstance().Clients.AddClientAsync(c);

            Console.WriteLine("ClientID:{0}", newClient.Id);
            Console.Read();
        }
        static async Task GetClient()
        {
            Console.WriteLine("Request client...");
            const string clientId = "client_ad591663d69051d306a8";
            var c = await CreatePaymillInstance().Clients.GetClientAsync(clientId);

            Console.WriteLine("ClientID:{0}", c.Id);
            Console.WriteLine("Created at:{0}", c.CreatedAt.ToShortDateString());
            Console.Read();
        }
        static async Task UpdateClient()
        {
            var c = new Client
            {
                Description = "Javier",
                Email = "javicantos33@hotmail.es",
                Id = "client_bbe895116de80b6141fd"
            };

            var updatedClient = await CreatePaymillInstance().Clients.UpdateClientAsync(c);

            Console.WriteLine("ClientID:{0}", updatedClient.Id);
            Console.Read();
        }
        static async Task RemoveClient()
        {
            // lo borra pero no devuelve blanco
            // devuelve el objeto cliente con el identificador pasado por parametro

            Console.WriteLine("Removing client...");

            const string clientId = "client_180ad3d1042a1da4a0a0";
            var reply = await CreatePaymillInstance().Clients.RemoveClientAsync(clientId);

            Console.WriteLine("Result remove:{0}", reply);
            Console.Read();
        }

        // offers
        static async Task GetOffers()
        {
            Console.WriteLine("Waiting request list offers...");
            var lstOffers = await CreatePaymillInstance().Offers.GetOffersAsync();

            foreach (var o in lstOffers)
            {
                Console.WriteLine("OfferID:{0}", o.Id);
            }

            Console.Read();
        }
        static async Task GetOffersWithParameters()
        {
            Console.WriteLine("Waiting request list offers with parameters...");

            var filter = new Filter();
            filter.Add("count", 1); //OK
            filter.Add("offset", 2); //OK
            //filter.Add("interval","month"); //OK
            //filter.Add("amount", 495); //OK
            //filter.Add("created_at", span.TotalSeconds.ToString()); //KO
            //filter.Add("trial_period_days", 5); //OK

            var lstOffers = await CreatePaymillInstance().Offers.GetOffersAsync(filter);

            foreach (var o in lstOffers)
            {
                Console.WriteLine("OfferID:{0}", o.Id);
            }

            Console.Read();
        }
        static async Task AddOffer()
        {
            var offer = new Offer
            {
                Amount = 1500,
                Currency = "eur",
                Interval = Offer.TypeInterval.Month,
                Name = "Prueba API",
                TrialPeriodDays = 3
            };

            var newOffer = await CreatePaymillInstance().Offers.AddOfferAsync(offer);

            Console.WriteLine("OfferID:{0}", newOffer.Id);
            Console.Read();
        }
        static async Task GetOffer()
        {
            Console.WriteLine("Request offer...");
            const string offerId = "offer_6eea405f83d4d3098604";
            var offer = await CreatePaymillInstance().Offers.GetOfferAsync(offerId);

            Console.WriteLine("OfferID:{0}", offer.Id);
            Console.WriteLine("Created at:{0}", offer.CreatedAt.ToShortDateString());
            Console.Read();
        }
        static async Task UpdateOffer()
        {
            var offer = new Offer
            {
                Name = "Oferta 48", 
                Id = "offer_6eea405f83d4d3098604"
            };

            var updatedOffer = await CreatePaymillInstance().Offers.UpdateOfferAsync(offer);

            Console.WriteLine("OfferID:{0}", updatedOffer.Id);
            Console.Read();
        }
        static async Task RemoveOffer()
        {
            Console.WriteLine("Removing offer...");

            const string offerId = "offer_6eea405f83d4d3098604";
            var reply = await CreatePaymillInstance().Offers.RemoveOfferAsync(offerId);

            Console.WriteLine("Result remove:{0}", reply);
            Console.Read();
        }

        // subscriptions
        static async Task GetSubscriptions()
        {
            Console.WriteLine("Waiting request list subscriptions...");
            var lstSubscriptions = await CreatePaymillInstance().Subscriptions.GetSubscriptionsAsync();

            foreach (var s in lstSubscriptions)
            {
                Console.WriteLine("SubscriptionID:{0}", s.Id);
            }

            Console.Read();
        }
        static async Task GetSubscriptionsWithParameters()
        {
            Console.WriteLine("Waiting request list subscriptions with parameters...");

            var filter = new Filter();
            filter.Add("count", 1); //OK
            filter.Add("offset", 2); //OK
            //filter.Add("offer", "offer_32008ddd39954e71ed48"); //KO
            //filter.Add("canceled_at", 495); //KO
            //filter.Add("created_at", 1353194860); //KO

            var lstSubscriptions = await CreatePaymillInstance().Subscriptions.GetSubscriptionsAsync(filter);

            foreach (var s in lstSubscriptions)
            {
                Console.WriteLine("SubscriptionID:{0}", s.Id);
            }

            Console.Read();
        }
        static async Task AddSubscription()
        {
            var subscription = new Subscription
            {
                Client = new Client {Id = "client_bbe895116de80b6141fd"},
                Offer = new Offer {Id = "offer_32008ddd39954e71ed48"},
                Payment = new Payment {Id = "pay_81ec02206e9b9c587513"}
            };

            var newSubscription = await CreatePaymillInstance().Subscriptions.AddSubscriptionAsync(subscription);

            Console.WriteLine("SubscriptionID:{0}", newSubscription.Id);
            Console.Read();
        }
        static async Task GetSubscription()
        {
            Console.WriteLine("Request subscription...");
            const string subscriptionId = "sub_e77d3332e456674101ad";
            var subscription = await CreatePaymillInstance().Subscriptions.GetSubscriptionAsync(subscriptionId);

            Console.WriteLine("SubscriptionID:{0}", subscription.Id);
            Console.WriteLine("Created at:{0}", subscription.CreatedAt.ToShortDateString());
            Console.Read();
        }
        static async Task UpdateSubscription()
        {
            var subscription = new Subscription
            {
                CancelAtPeriodEnd = true, 
                Id = "sub_569df922b4506cd73030"
            };

            var updatedSubscription = await CreatePaymillInstance().Subscriptions.UpdateSubscriptionAsync(subscription);

            Console.WriteLine("SubscriptionID:{0}", updatedSubscription.Id);
            Console.Read();
        }
        static async Task RemoveSubscription()
        {
            // se elimina correctamente pero el json de respuesta no devuelve vacio 

            Console.WriteLine("Removing subscription...");

            const string subscriptionId = "sub_569df922b4506cd73030";
            var reply = await CreatePaymillInstance().Subscriptions.RemoveSubscriptionAsync(subscriptionId);

            Console.WriteLine("Result remove:{0}", reply);
            Console.Read();
        }
    }

}