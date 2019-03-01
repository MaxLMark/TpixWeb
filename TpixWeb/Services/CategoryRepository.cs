using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TpixWeb.Models;

namespace TpixWeb.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IRestClient _restClient;
        private string baseUrl;
        public CategoryRepository(IRestClient restClient, IConfiguration configuration)
        {
            _restClient = restClient;
            baseUrl = configuration.GetSection("ApiUrl").Value + "/categories/";
        }

        string methodUrl = "/categories/";

        public Task<Category> DeleteCategory(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> GetAllCategories()
        {
            return _restClient.GetAsync<List<Category>>($"{baseUrl}{methodUrl}");
        }

        public Task<List<Category>> GetCategoriesByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public Task<Category> PostCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
