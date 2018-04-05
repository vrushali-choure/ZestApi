using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI_ZEST.Helpers
{
    public class JsonMethods
    {
        /// <summary>
        /// Serializes the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>returns string</returns>
        public static string Serialize(object value)
        {
            return JsonConvert.SerializeObject(value);
        }

        /// <summary>
        /// js the object parse.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>returns JObject</returns>
        public static JObject JObjectParse(string value)
        {
            return JObject.Parse(value);
        }

        /// <summary>
        /// Deserializes the specified value.
        /// </summary>
        /// <typeparam name="T">The generic</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>returns Generic T</returns>
        public static T Deserialize<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }

        /// <summary>
        /// Deserializes the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>returns object</returns>
        public static object Deserialize(string value)
        {
            return JsonConvert.DeserializeObject(value);
        }

        /// <summary>
        /// Gets the serializer.
        /// </summary>
        /// <returns>returns JsonSerializer</returns>
        public static JsonSerializer GetSerializer()
        {
            // make a new Json serializer
            var serializer = new JsonSerializer();

            // add the dyamic object converter to our serializer
            serializer.Converters.Add(new ExpandoObjectConverter());

            foreach (var customJsonConverter in GetCustomJsonConverters())
            {
                serializer.Converters.Add(customJsonConverter);
            }

            return serializer;
        }

        /// <summary>
        /// Creates the json request.
        /// </summary>
        /// <param name="jsonString">The json string.</param>
        /// <returns>returns string</returns>
        public static string CreateJsonRequest(string jsonString)
        {
            return CreateJsonRequest(jsonString, false);
        }

        /// <summary>
        /// Creates the json request.
        /// </summary>
        /// <param name="jsonString">The json string.</param>
        /// <param name="isEncrypted">The is encrypted.</param>
        /// <returns>returns string</returns>
        public static string CreateJsonRequest(string jsonString, bool? isEncrypted)
        {
            ////return "{ \"" + Constants.RequestJSON + "\" : " + jsonString + " }";

            return jsonString;
        }

        /// <summary>
        /// Creates the json response.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>returns object</returns>
        public static object CreateJsonResponse(object value)
        {
            return CreateJsonResponse(value, Convert.ToBoolean(false));
        }

        /// <summary>
        /// Creates the json response.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="isEncrypted">if set to <c>true</c> [is encrypted].</param>
        /// <returns>returns object</returns>
        public static object CreateJsonResponse(object value, bool isEncrypted)
        {
            return value;
        }

        /// <summary>
        /// Gets the content of the object.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="value">The value.</param>
        /// <returns>returns objectContext</returns>
        public static ObjectContent GetObjectContent(Type type, object value)
        {
            var json = new JsonMediaTypeFormatter { SerializerSettings = { TypeNameHandling = TypeNameHandling.All } };

            // Create the JSON formatter.
            MediaTypeFormatter jsonFormatter = json;

            // Use the JSON formatter to create the content of the request body.
            return new ObjectContent(type, value, jsonFormatter);
        }

        /// <summary>
        /// Gets the custom json converters.
        /// </summary>
        /// <returns>returns JsonConverter[]</returns>
        private static JsonConverter[] GetCustomJsonConverters()
        {
            return new JsonConverter[] { new JsonDateTimeConvertor() };
        }
        public class JsonDateTimeConvertor : JsonConverter
        {
            /// <summary>
            /// Writes the JSON representation of the object.
            /// </summary>
            /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter" /> to write to.</param>
            /// <param name="value">The value.</param>
            /// <param name="serializer">The calling serializer.</param>
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                writer.WriteValue(((DateTime)value).ToString(CultureInfo.InvariantCulture));
            }

            /// <summary>
            /// Reads the JSON representation of the object.
            /// </summary>
            /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader" /> to read from.</param>
            /// <param name="objectType">Type of the object.</param>
            /// <param name="existingValue">The existing value of object being read.</param>
            /// <param name="serializer">The calling serializer.</param>
            /// <returns>
            /// The object value.
            /// </returns>
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                return DateTime.Parse(reader.Value.ToString(), CultureInfo.InvariantCulture);
            }

            /// <summary>
            /// Determines whether this instance can convert the specified object type.
            /// </summary>
            /// <param name="objectType">Type of the object.</param>
            /// <returns>
            /// <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
            /// </returns>
            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(DateTime) || objectType == typeof(DateTime?);
            }
        }
    }
}
