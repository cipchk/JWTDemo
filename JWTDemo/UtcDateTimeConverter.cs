using Newtonsoft.Json;
using System;

namespace JWTDemo
{
    public class UtcDateTimeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null) return null;
            DateTime time = DateTime.MinValue;
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            time = startTime.AddSeconds((double)reader.Value);
            return time;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var ticks = Decimal.ToInt64(Decimal.Divide(((DateTime)value).Ticks - 621355968000000000, 10000));
            writer.WriteValue(ticks);
        }
    }
}