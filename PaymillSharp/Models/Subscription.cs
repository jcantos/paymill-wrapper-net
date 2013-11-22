﻿using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using PaymillSharp.Internal;

namespace PaymillSharp.Models
{
    /// <summary>
    /// Subscriptions allow you to charge recurring payments on a client’s credit card / to a client’s direct debit. 
    /// A subscription connects a client to the offers-object.
    /// </summary>
    [JsonConverter(typeof(StringToBaseModelConverter<Subscription>))]
    public class Subscription : BaseModel, IQueryableOffer
    {
        /// <summary>
        /// Hash describing the offer which is subscribed to the client
        /// </summary>
        [DataMember(Name = "offer")]
        public Offer Offer { get; set; }

        /// <summary>
        /// Whether this subscription was issued while being in live mode or not
        /// </summary>
        [DataMember(Name = "livemode")]
        public bool Livemode { get; set; }

        /// <summary>
        /// Cancel this subscription immediately or at the end of the current period?
        /// </summary>
        [DataMember(Name = "cancel_at_period_end")]
        public bool CancelAtPeriodEnd { get; set; }

        [DataMember(Name = "trial_start")]
        public DateTime? TrialStart { get; set; }

        [DataMember(Name = "trial_end")]
        public DateTime? TrialEnd { get; set; }

        /// <summary>
        /// Next charge date.
        /// </summary>
        [DataMember(Name = "next_capture_at")]
        public DateTime NextCaptureAt { get; set; }

        /// <summary>
        /// Cancel date
        /// </summary>
        [DataMember(Name = "canceled_at")]
        public DateTime? CanceledAt { get; set; }

        /// <summary>
        /// Client-object
        /// </summary>
        [DataMember(Name = "client")]
        public Client Client { get; set; }

        /// <summary>
        /// Payment-object
        /// </summary>
        [DataMember(Name = "payment")]
        public Payment Payment { get; set; }
    }
}