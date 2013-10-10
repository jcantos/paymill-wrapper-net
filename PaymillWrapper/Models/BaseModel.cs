using System;
using System.Runtime.Serialization;

namespace PaymillWrapper.Models
{
    [DataContract]
    public class BaseModel
    {
        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).ToLocalTime();

        /// <summary>
        /// Unique identifier
        /// </summary>
        [DataMember(Name = "Id")]
        public string Id { get; set; }

        /// <summary>
        /// Creation date
        /// </summary>
        [IgnoreDataMember]
        public DateTime CreatedAt { get; set; }

        [DataMember(Name = "Created_At")]
        private int CreatedAtTicks
        {
            get { return (int)(CreatedAt - UnixEpoch).TotalSeconds; }
            set { CreatedAt = UnixEpoch.AddSeconds(value); }
        }

        /// <summary>
        /// Last update
        /// </summary>
        [IgnoreDataMember]
        public DateTime UpdatedAt { get; set; }

        [DataMember(Name = "Updated_At")]
        private int UpdatedAtTicks
        {
            get { return (int)(UpdatedAt - UnixEpoch).TotalSeconds; }
            set { UpdatedAt = UnixEpoch.AddSeconds(value); }
        }
    }
}
