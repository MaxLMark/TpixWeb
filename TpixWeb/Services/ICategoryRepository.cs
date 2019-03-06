using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TpixWeb.Models;

namespace TpixWeb.Services
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategories();
        Task<List<Category>> GetCategoriesByTitle(string title);
        Task<bool> UpdateCategory(Category category);
        Task<Category> AddCategory(Category category);
        Task<Category> DeleteCategory(int Id);
        Task<Category> GetCategoryById(int Id);
     }
}
