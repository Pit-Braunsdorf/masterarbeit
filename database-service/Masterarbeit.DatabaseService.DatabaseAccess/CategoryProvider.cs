using System.Collections.Generic;
using System.Linq;
using Masterarbeit.DatabaseService.Contracts;
using Masterarbeit.DatabaseService.Database;
using Masterarbeit.DatabaseService.DatabaseAccess.Helper;

namespace Masterarbeit.DatabaseService.DatabaseAccess
{
    public class CategoryProvider
    {
        private readonly DatabaseContext _databaseContext;

        public CategoryProvider(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public Category Get(int id)
        {
            var dbCategory = _databaseContext.Categories.Single(cat => cat.Id == id);
            return MappingHelper.Map(dbCategory);
        }

        public IEnumerable<Category> Get()
        {
            var dbCategories = _databaseContext.Categories.AsEnumerable();
            return MappingHelper.Map(dbCategories);
        }

        public void Create(Category category)
        {
            var dbCategory = MappingHelper.Map(category);
            _databaseContext.Categories.Add(dbCategory);
            _databaseContext.SaveChanges();
        }

        public void Create(IEnumerable<Category> categories)
        {
            var dbCategories = MappingHelper.Map(categories);
            _databaseContext.Categories.AddRange(dbCategories);
            _databaseContext.SaveChanges();
        }

        public void Update(Category category)
        {
            var dbCategory = MappingHelper.Map(category);
            _databaseContext.Categories.Attach(dbCategory);
            _databaseContext.SaveChanges();
        }

        public void Delete(Category category)
        {
            var dbCategory = MappingHelper.Map(category);
            _databaseContext.Remove(dbCategory);
            _databaseContext.SaveChanges();
        }

        public void Delete(IEnumerable<Category> categories)
        {
            var dbCategories = MappingHelper.Map(categories);
            _databaseContext.RemoveRange(dbCategories);
            _databaseContext.SaveChanges();
        }
    }
}
