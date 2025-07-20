using Microsoft.AspNetCore.Http;
using System.Text.Json;  // Use System.Text.Json

namespace GiftCardsShop
{
    public static class SessionExtensions
    {
        // Store object as JSON in session
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));  // Use JsonSerializer.Serialize
        }

        // Retrieve object from JSON in session
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);  // Use JsonSerializer.Deserialize
        }
    }
}
