using System.Collections.Generic;
using System.Linq;
using Masterarbeit.DatabaseService.Contracts;
using Masterarbeit.DatabaseService.Database;
using Masterarbeit.DatabaseService.DatabaseAccess.Helper;

namespace Masterarbeit.DatabaseService.DatabaseAccess
{
    public class ImageProvider
    {
        private readonly DatabaseContext _databaseContext;

        public ImageProvider(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public Image Get(int id)
        {
            var dbImage = _databaseContext.Images.Single(x => x.Id == id);
            return MappingHelper.Map(dbImage);
        }

        public IEnumerable<Image> Get()
        {
            var dbImages = _databaseContext.Images.AsEnumerable();
            return MappingHelper.Map(dbImages);
        }

        public void Create(Image image)
        {
            var dbImage = MappingHelper.Map(image);
            _databaseContext.Images.Add(dbImage);
            _databaseContext.SaveChanges();
        }

        public void Create(IEnumerable<Image> images)
        {
            var dbImages = MappingHelper.Map(images);
            _databaseContext.Images.AddRange(dbImages);
            _databaseContext.SaveChanges();
        }

        public void Update(Image image)
        {
            var dbImage = MappingHelper.Map(image);
            _databaseContext.Attach(dbImage);
            _databaseContext.SaveChanges();
        }

        public void Delete(Image image)
        {
            var dbImage = MappingHelper.Map(image);
            _databaseContext.Images.Remove(dbImage);
            _databaseContext.SaveChanges();
        }

        public void Delete(IEnumerable<Image> images)
        {
            var dbImages = MappingHelper.Map(images);
            _databaseContext.Images.RemoveRange(dbImages);
            _databaseContext.SaveChanges();
        }
    }
}
