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

        public Task<Category> DeleteCategory(int Id)
        {
            return _restClient.DeleteAsync<Category>($"{baseUrl}{Id}");
        }

        public Task<List<Category>> GetAllCategories()
        {
            return _restClient.GetAsync<List<Category>>($"{baseUrl}");
        }

        public Task<List<Category>> GetCategoriesByTitle(string title)
        {
            return _restClient.GetAsync<List<Category>>($"{baseUrl}{title}");
        }

        public Task<Category> GetCategoryById(int Id)
        {
            return _restClient.GetAsync<Category>($"{baseUrl}GetCategoryById/{Id}");
        }

        public Task<Category> AddCategory(Category category)
        {
            return _restClient.PostAsync<Category>($"{baseUrl}", category);
        }

        public Task<bool> UpdateCategory(Category category)
        {
            return _restClient.PutAsync<bool>($"{baseUrl}", category);
        }
    }
}
