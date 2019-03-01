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

        string method = "/topic/";

        public Task<Topic> DeleteTopic(int Id)
        {
            throw new NotImplementedException();
        }

        public Task EditTopic(Topic topic)
        {
            throw new NotImplementedException();
        }

        public Task<Topic> GetTopic(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Topic>> GetTopicsByCategoryId(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task PostTopic(Topic topic)
        {
            throw new NotImplementedException();
        }
    }
}
