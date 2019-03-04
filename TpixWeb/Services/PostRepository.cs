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

        public Task<Post> AddPost(Post post)
        {
            return _restClient.PostAsync<Post>($"{baseUrl}", post);
        }

        public Task<Post> DeletePost(int Id)
        {
            return _restClient.DeleteAsync<Post>($"{baseUrl}{Id}");
        }

        public Task<bool> EditPost(Post post)
        {
            return _restClient.PutAsync<bool>($"{baseUrl}", post);
        }

        public Task<Post> GetPost(int Id)
        {
            return _restClient.GetAsync<Post>($"{baseUrl}{Id}");
        }

        public Task<List<Post>> GetPostsByTopicId(int topicId)
        {
            return _restClient.GetAsync<List<Post>>($"{baseUrl}GetPostsForTopic/{topicId}");
        }
    }
}
