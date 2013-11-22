using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymillSharp.Internal;
using PaymillSharp.Models;

namespace UnitTest.Internal
{
    [TestClass]
    public class TestUrlEncoder
    {
        /// <summary>
        /// Gets or sets the test context which provides information and functionality for 
        /// the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        #region Atributos de prueba adicionales
        //
        // Puede usar los siguientes atributos adicionales conforme escribe las pruebas:
        //
        // Use ClassInitialize para ejecutar el código antes de ejecutar la primera prueba en la clase
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup para ejecutar el código una vez ejecutadas todas las pruebas en una clase
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Usar TestInitialize para ejecutar el código antes de ejecutar cada prueba 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup para ejecutar el código una vez ejecutadas todas las pruebas
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void EncodeTransaction()
        {
            var urlEncoder = new UrlEncoder();

            var transaction = new Transaction
            {
                Token = "098f6bcd4621d373cade4e832627b4f6",
                Amount = 3500,
                Currency = "EUR",
                Description = "Prueba"
            };

            const string expected = "amount=3500&currency=EUR&token=098f6bcd4621d373cade4e832627b4f6&description=Prueba";
            var reply = urlEncoder.EncodeTransaction(transaction);

            Assert.AreEqual(expected, reply);
        }

        [TestMethod]
        public void EncodePreauthorization()
        {
            var urlEncoder = new UrlEncoder();

            var preauthorization = new Preauthorization
            {
                Amount = 3500,
                Currency = "EUR",
                Payment = new Payment {Id = "pay_4c159fe95d3be503778a"}
            };

            const string expected = "amount=3500&currency=EUR&payment=pay_4c159fe95d3be503778a";
            var reply = urlEncoder.EncodePreauthorization(preauthorization);

            Assert.AreEqual(expected, reply);
        }

        [TestMethod]
        public void EncodeRefund()
        {
            var urlEncoder = new UrlEncoder();

            var refund = new Refund
            {
                Amount = 500,
                Description = "Prueba",
                Transaction = new Transaction {Id = "tran_a7c93a1e5b431b52c0f0"}
            };

            const string expected = "amount=500&description=Prueba";
            var reply = urlEncoder.EncodeRefund(refund);

            Assert.AreEqual(expected, reply);
        }

        [TestMethod]
        public void EncodeOfferAdd()
        {
            var urlEncoder = new UrlEncoder();

            var offer = new Offer
            {
                Amount = 1500,
                Currency = "eur",
                Interval = "1 MONTH",
                Name = "Prueba API",
                TrialPeriodDays = 3
            };

            const string expected = "amount=1500&currency=eur&interval=1+MONTH&name=Prueba+API";
            var reply = urlEncoder.EncodeOfferAdd(offer);

            Assert.AreEqual(expected, reply);
        }

        [TestMethod]
        public void EncodeOfferUpdate()
        {
            var urlEncoder = new UrlEncoder();

            var offer = new Offer
            {
                Name = "Oferta 48", 
                Id = "offer_6eea405f83d4d3098604",
                Interval = "1 WEEK"
            };

            const string expected = "amount=0&interval=1+WEEK&name=Oferta+48";
            var reply = urlEncoder.EncodeOfferAdd(offer);

            Assert.AreEqual(expected, reply);
        }

        [TestMethod]
        public void EncodeSubscriptionAdd()
        {
            var urlEncoder = new UrlEncoder();

            var subscription = new Subscription
            {
                Client = new Client {Id = "client_bbe895116de80b6141fd"},
                Offer = new Offer {Id = "offer_32008ddd39954e71ed48"},
                Payment = new Payment {Id = "pay_81ec02206e9b9c587513"}
            };

            const string expected = "client=client_bbe895116de80b6141fd&offer=offer_32008ddd39954e71ed48&payment=pay_81ec02206e9b9c587513";
            var reply = urlEncoder.EncodeSubscriptionAdd(subscription);

            Assert.AreEqual(expected, reply);
        }

        [TestMethod]
        public void EncodeSubscriptionUpdate()
        {
            var urlEncoder = new UrlEncoder();

            var subscription = new Subscription
            {
                CancelAtPeriodEnd = true, 
                Id = "sub_569df922b4506cd73030"
            };

            const string expected = "cancel_at_period_end=True";
            var reply = urlEncoder.EncodeSubscriptionUpdate(subscription);

            Assert.AreEqual(expected, reply);
        }

        [TestMethod]
        public void EncodeClientAdd()
        {
            var urlEncoder = new UrlEncoder();

            var c = new Client
            {
                Description = "Prueba", 
                Email = "javicantos22@hotmail.es"
            };

            const string expected = "email=javicantos22%40hotmail.es&description=Prueba";
            var reply = urlEncoder.Encode<Client>(c);

            Assert.AreEqual(expected, reply);
        }

        [TestMethod]
        public void EncodeClientUpdate()
        {
            var urlEncoder = new UrlEncoder();

            var c = new Client
            {
                Description = "Javier",
                Email = "javicantos33@hotmail.es",
                Id = "client_bbe895116de80b6141fd"
            };

            const string expected = "email=javicantos33%40hotmail.es&description=Javier&id=client_bbe895116de80b6141fd";
            var reply = urlEncoder.Encode<Client>(c);

            Assert.AreEqual(expected, reply);
        }
    }
}
