using EventHub.Models;
using System.Collections.Generic;

namespace EventHub.Repository
{
    public interface ICategoryRepository
    {
        void InsertCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int categoryid);
        Category GetCategoryById(int Id);
        IEnumerable<Category> GetCategory();
    }
}
