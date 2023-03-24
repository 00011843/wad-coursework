using EventHubAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventHubAPI.Repositories
{
    internal interface ICategoryRepository
    {
        void CreateNewCategory(Category category);

        IEnumerable<Category> GetAllCategories();

        Category GetCategoryById(int CategoryId);

        void DeleteCategoryById(int CategoryId);

        void UpdateCategory(Category category);
    }
}
