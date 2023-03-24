using EventHubAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventHubAPI.Repositories
{
    public interface ICategoryRepository
    {
        void CreateNewCategory(Category category);

        IEnumerable<Category> GetAllCategories();

        Category GetCategoryById(int CategoryId);

        void DeleteCategoryById(int CategoryId);

        void UpdateCategory(Category category);
    }
}
