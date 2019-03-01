using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TpixWeb.Models;

namespace TpixWeb.Services
{
    public interface IPostRepository
    {
        Task<Post> GetPost(int Id);
        Task<List<Post>> GetPostsByTopicId(int topicId);
        Task<bool> EditPost(Post post);
        Task<Post> AddPost(Post post);
        Task<Post> DeletePost(int Id);
    }
}
