using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace TpixWeb.Services
{
    public interface IRestClient
    {
        Task<TResponse> PostAsync<TResponse>(string url, object requestBody);
        Task<TResponse> GetAsync<TResponse>(string url);
        Task<TResponse> GetAsync<TResponse>(string url, object requestBody);
        Task<TResponse> SendAsync<TResponse>(HttpMethod method, string url, object requestBody = null);
        Task<TResponse> PutAsync<TResponse>(string url, object requestBody);
        Task<TResponse> DeleteAsync<TResponse>(string url);

    }
}