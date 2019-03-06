using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TpixWeb.Models;

namespace TpixWeb.Services
{
    public class TopicRepository : ITopicRepository
    {
        private readonly IRestClient _restClient;
        private string baseUrl;
        public TopicRepository(IRestClient restClient, IConfiguration configuration)
        {
            _restClient = restClient;
            baseUrl = configuration.GetSection("ApiUrl").Value + "/topic/";
        }

        public Task<Topic> DeleteTopic(int Id)
        {
            return _restClient.DeleteAsync<Topic>($"{baseUrl}");
        }

        public Task EditTopic(Topic topic)
        {
            return _restClient.PutAsync<bool>($"{baseUrl}", topic);
        }

        public Task<Topic> GetTopic(int Id)
        {
            return _restClient.GetAsync<Topic>($"{baseUrl}{Id}");
        }

        public Task<List<Topic>> GetTopicsByCategoryId(int categoryId)
        {
            return _restClient.GetAsync<List<Topic>>($"{baseUrl}GetTopicsForCategory/{categoryId}");
        }

        public Task AddTopic(Topic topic)
        {
            return _restClient.PostAsync<Task>($"{baseUrl}", topic);
        }
    }
}
