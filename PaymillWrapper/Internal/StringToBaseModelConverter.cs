using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PaymillWrapper.Models;
using System;
using System.Reflection;

namespace PaymillWrapper.Internal
{
    class StringToBaseModelConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(BaseModel);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                var jObject = JObject.Load(reader);
                var target = (T)Activator.CreateInstance(typeof(T));
                serializer.Populate(jObject.CreateReader(), target);

                return target;
            }
            catch(Exception)
            {
                var target = (T)Activator.CreateInstance(typeof(T));

                if (reader.Value != null)
                {
                    var prop = target.GetType().GetProperty("Id", BindingFlags.Public | BindingFlags.Instance);
                    if (null != prop && prop.CanWrite)
                        prop.SetValue(target, reader.Value.ToString(), null);
                }

                return target;
            }

        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
