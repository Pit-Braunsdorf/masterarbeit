using System;
using System.Collections.Generic;
using System.Text;
using Masterarbeit.DatabaseService.Contracts;
using Masterarbeit.DatabaseService.DatabaseAccess;

namespace Masterarbeit.DatabaseService.App
{
    public class ImageInteractor
    {
        private readonly ImageProvider _imageProvider;

        public ImageInteractor(ImageProvider imageProvider)
        {
            _imageProvider = imageProvider;
        }

        public Image Get(int id)
        {
            return _imageProvider.Get(id);
        }

        public IEnumerable<Image> Get()
        {
            return _imageProvider.Get();
        }

        public void Create(Image image)
        {
            _imageProvider.Create(image);
        }

        public void Create(IEnumerable<Image> images)
        {
            _imageProvider.Create(images);
        }

        public void Update(Image image)
        {
            _imageProvider.Update(image);
        }

        public void Delete(int id)
        {
            var image = _imageProvider.Get(id);
            _imageProvider.Delete(image);
        }

        public void Delete(Image image)
        {
            _imageProvider.Delete(image);
        }

        public void Delete(IEnumerable<Image> images)
        {
            _imageProvider.Delete(images);
        }
    }
}
