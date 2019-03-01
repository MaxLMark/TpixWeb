using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace TpixWeb.Services
{
    public class JsonContent : StringContent
    {
        public JsonContent(object obj) :
            base(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json") { }

        public JsonContent(object obj, JsonSerializerSettings serializerSettings) :
            base(JsonConvert.SerializeObject(obj, serializerSettings), Encoding.UTF8, "application/json") { }
    }
}
