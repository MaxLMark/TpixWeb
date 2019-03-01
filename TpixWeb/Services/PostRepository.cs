using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TpixWeb.Models;

namespace TpixWeb.Services
{
    public class PostRepository : IPostRepository
    {
        private readonly IRestClient _restClient;
        private string baseUrl;
        public PostRepository(IRestClient restClient, IConfiguration configuration)
        {
            _restClient = restClient;
            baseUrl = configuration.GetSection("ApiUrl").Value + "/posts/";
        }

        string method = "/posts/";

        public Task<Post> AddPost(Post post)
        {
            var test = _restClient.PostAsync<Post>($"{baseUrl}{method}", post);



            return test;
        }

        public Task<Post> DeletePost(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditPost(Post post)
        {
            throw new NotImplementedException();
        }

        public Task<Post> GetPost(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Post>> GetPostsByTopicId(int topicId)
        {
            throw new NotImplementedException();
        }
    }
}
