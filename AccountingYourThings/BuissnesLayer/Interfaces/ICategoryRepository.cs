using DataLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.DTO;

namespace BusinessLayer.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<CategoryDTO>> GetAllCategories();
        CategoryDTO GetCategoryById(int categoryId);
        void SaveCategory(CategoryDTO category);
        void DeleteCategory(int categoryId);
    }
}
