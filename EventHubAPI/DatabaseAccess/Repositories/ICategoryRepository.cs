using DatabaseAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.Repositories
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
