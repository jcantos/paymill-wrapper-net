﻿using System.Net.Http;
using PaymillSharp.Internal;
using PaymillSharp.Models;

namespace PaymillSharp.Service
{
    class PaymentService : AbstractService<Payment>
    {
        public PaymentService(HttpClient client, string apiUrl)
            : base(Resource.Payments, client, apiUrl)
        {
        }

        protected override string GetResourceId(Payment obj)
        {
            return obj.Id;
        }

        protected override string GetEncodedCreateParams(Payment obj, UrlEncoder encoder)
        {
            return encoder.Encode<Payment>(obj);
        }

        protected override string GetEncodedUpdateParams(Payment obj, UrlEncoder encoder)
        {
            throw new System.NotImplementedException();
        }
    }
}