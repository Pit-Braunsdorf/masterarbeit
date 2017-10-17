using System;
using System.Collections.Generic;
using System.Text;
using Masterarbeit.Shared.Contracts;
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

        public Image Create(Image image)
        {
            return _imageProvider.Create(image);
        }

        public IEnumerable<Image> Create(IEnumerable<Image> images)
        {
            return _imageProvider.Create(images);
        }

        public void Update(Image image)
        {
            try
            {
                _imageProvider.Update(image);
            }
            catch (Exception e)
            {
                throw e;
            }
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
