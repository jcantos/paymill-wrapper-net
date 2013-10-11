using System;
using System.Runtime.Serialization;

namespace PaymillWrapper.Models
{
    [DataContract]
    public class BaseModel
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        [DataMember(Name = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Creation date
        /// </summary>
        [IgnoreDataMember]
        public DateTime CreatedAt { get; set; }

        [DataMember(Name = "created_at")]
        private int CreatedAtTicks
        {
            get { return CreatedAt.ToUnixTimestamp(); }
            set { CreatedAt = value.ParseAsUnixTimestamp(); }
        }

        /// <summary>
        /// Last update
        /// </summary>
        [IgnoreDataMember]
        public DateTime UpdatedAt { get; set; }

        [DataMember(Name = "updated_at")]
        private int UpdatedAtTicks
        {
            get { return UpdatedAt.ToUnixTimestamp(); }
            set { UpdatedAt = value.ParseAsUnixTimestamp(); }
        }
    }
}
