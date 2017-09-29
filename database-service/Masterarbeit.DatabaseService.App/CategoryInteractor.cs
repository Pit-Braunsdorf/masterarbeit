using System;
using System.Collections.Generic;
using System.Text;
using Masterarbeit.DatabaseService.Contracts;
using Masterarbeit.DatabaseService.DatabaseAccess;

namespace Masterarbeit.DatabaseService.App
{
    public class CategoryInteractor
    {
        private readonly CategoryProvider _categoryProvider;

        public CategoryInteractor(CategoryProvider categoryProvider)
        {
            _categoryProvider = categoryProvider;
        }

        public Category Get(int id)
        {
            return _categoryProvider.Get(id);
        }

        public object Get()
        {
            return _categoryProvider.Get();
        }

        public void Create(Category category)
        {
            _categoryProvider.Create(category);
        }

        public void Create(IEnumerable<Category> categories)
        {
            _categoryProvider.Create(categories);
        }

        public void Update(Category category)
        {
            _categoryProvider.Update(category);
        }

        public void Delete(int id)
        {
            var cat = _categoryProvider.Get(id);
            _categoryProvider.Delete(cat);
        }

        public void Delete(Category category)
        {
            _categoryProvider.Delete(category);
        }

        public void Delete(IEnumerable<Category> categories)
        {
            _categoryProvider.Delete(categories);
        }
    }
}
