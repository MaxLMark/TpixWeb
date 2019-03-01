using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TpixWeb.Services
{
    public class JsonRestClient : IRestClient
    {
        private static MediaTypeWithQualityHeaderValue AcceptHeader => new MediaTypeWithQualityHeaderValue("application/json");

        public async Task<TResponse> PostAsync<TResponse>(string url, object requestBody)
        {
            return await SendAsync<TResponse>(HttpMethod.Post, url, requestBody);
        }

        public async Task<TResponse> GetAsync<TResponse>(string url)
        {
            return await SendAsync<TResponse>(HttpMethod.Get, url, null);
        }
        public async Task<TResponse> GetAsync<TResponse>(string url, object requestBody)
        {
            return await SendAsync<TResponse>(HttpMethod.Get, url, requestBody);
        }

        public async Task<TResponse> PutAsync<TResponse>(string url, object requestBody)
        {
            return await SendAsync<TResponse>(HttpMethod.Put, url, requestBody);
        }

        public async Task<TResponse> DeleteAsync<TResponse>(string url)
        {
            return await SendAsync<TResponse>(HttpMethod.Delete, url, null);
        }

        public async Task<TResponse> SendAsync<TResponse>(HttpMethod method, string url, object requestBody = null)
        {
            using (var client = new HttpClient()) {
                client.DefaultRequestHeaders.Accept.Add(AcceptHeader);

                //OBS!!!
                //Måste eventuellt byta request type till application/x-www-form-urlencoded
                
                var request = new HttpRequestMessage(method, url);
                if (requestBody != null) {
                    request.Content = new JsonContent(requestBody);
                }
                var response = await client.SendAsync(request);
                var payload = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode) {
                    throw new JsonRestException(payload, (int) response.StatusCode, url, request);
                }

                return JsonConvert.DeserializeObject<TResponse>(payload);
            }
        }
    }
}