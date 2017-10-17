using System;
using System.Collections.Generic;
using System.Text;
using Masterarbeit.Frontend.AzureAccess;
using Masterarbeit.Frontend.Contracts;
using Masterarbeit.Frontend.DatabaseAccess;
using Masterarbeit.Shared.Contracts;

namespace Masterarbeit.Frontend.App
{
    public class ImageInteractor
    {
        private readonly ImageWebApiClient _imageWebApiClient;
        private readonly OcrAccess _ocrAccess;
        private WordWebApiClient _wordWebApiClient;

        public ImageInteractor(ImageWebApiClient imageWebApiClient, OcrAccess ocrAccess, WordWebApiClient wordWebApiClient)
        {
            _imageWebApiClient = imageWebApiClient;
            _ocrAccess = ocrAccess;
            _wordWebApiClient = wordWebApiClient;
        }

        public Image CreateImage(byte[] image)
        {
            return _imageWebApiClient.Post(new Image
            {
                ImageData = image,
                Categories = null,
                Words = null,
                UploadDate = DateTime.Now
            });
        }

        public OCRResult SendToOcr(byte[] image)
        {
            return _ocrAccess.SendAnalysisRequest(image);
        }
        public byte[] CreateThumbnail(byte[] image)
        {
            return _ocrAccess.CreateThumbnail(image);
        }


        public void SaveOCRResult(Image image, OCRResult ocrResult)
        {
            UpdateImageWithOCRResult(image, ocrResult);
            _imageWebApiClient.Put(image);
        }

        private void UpdateImageWithOCRResult(Image image, OCRResult ocrResult)
        {
            AddWordsToImage(image, ocrResult);
        }

        private static void AddWordsToImage(Image image, OCRResult ocrResult)
        {
            var words = new List<Word>();
            foreach (var region in ocrResult.Regions)
            {
                foreach (var line in region.Lines)
                {
                    words.AddRange(Shared.Helper.MappingHelper.Map(line.Words, ocrResult.Language));
                }
            }
            image.Words = words;
        }

        public List<Image> GetImages()
        {
            var images = _imageWebApiClient.Get();
            return images;
        }

        public Image GetImage(int id)
        {
            return _imageWebApiClient.Get(id);
        }

        public IEnumerable<Word> GetWordsForImage(int imageId)
        {
            return _wordWebApiClient.GetWordsForImage(imageId);
        }
    }
}
