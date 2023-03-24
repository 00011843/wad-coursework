using DatabaseAccess.DAL;
using DatabaseAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseAccess.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly EventContext __dbContext;

        public CategoryRepository(EventContext dbContext)
        {
            __dbContext = dbContext;
        }

        public void Save()
        {
            __dbContext.SaveChanges();
        }

        public void CreateNewCategory(Category category)
        {
            __dbContext.Add(category);
            Save();
        }

        public void DeleteCategoryById(int CategoryId)
        {
            var foundCategory = __dbContext.Categories.Find(CategoryId);
            __dbContext.Categories.Remove(foundCategory);
            Save();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return __dbContext.Categories.ToList();
        }

        public Category GetCategoryById(int CategoryId)
        {
            return __dbContext.Categories.Find(CategoryId);
        }

        public void UpdateCategory(Category category)
        {
            //Modify the category through EntityFrameworCore EnttiyState module
            __dbContext.Entry(category).State = EntityState.Modified;
            Save();
        }
    }
}
