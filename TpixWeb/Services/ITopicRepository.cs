using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TpixWeb.Models;

namespace TpixWeb.Services
{
    public interface ITopicRepository
    {
        Task<Topic> GetTopic(int Id);
        Task<List<Topic>> GetTopicsByCategoryId(int categoryId);
        Task AddTopic(Topic topic);
        Task EditTopic(Topic topic);
        Task<Topic> DeleteTopic(int Id);
    }
}
