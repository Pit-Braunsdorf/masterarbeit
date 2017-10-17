using System.Collections.Generic;
using System.Linq;
using Masterarbeit.Shared.Contracts;

namespace Masterarbeit.DatabaseService.DatabaseAccess.Helper
{
    public static class MappingHelper
    {
        public static Word Map(Database.Model.Word dbFixedWords)
        {
            return new Word
            {
                Id = dbFixedWords.Id,
                Inserted = dbFixedWords.Inserted,
                Updated = dbFixedWords.Updated,
                CorrectedWord = dbFixedWords.CorrectedWord,
                Language = dbFixedWords.Language,
                ReadWord = dbFixedWords.ReadWord
            };
        }

        public static Database.Model.Word Map(Word word)
        {
            return new Database.Model.Word
            {
                Id = word.Id,
                Inserted = word.Inserted,
                Updated = word.Updated,
                CorrectedWord = word.CorrectedWord,
                Language = word.Language,
                ReadWord = word.ReadWord
            };
        }

        public static IEnumerable<Word> Map(IEnumerable<Database.Model.Word> dbFixedWords)
        {
            return dbFixedWords.Select(Map);
        }

        public static IEnumerable<Database.Model.Image> Map(IEnumerable<Image> images)
        {
            return images.Select(Map);
        }

        public static Database.Model.Image Map(Image image)
        {
            return new Database.Model.Image
            {
                Id = image.Id,
                Words = image.Words != null ? Map(image.Words)?.ToList() : null,
                Categories =  image.Categories != null ? Map(image.Categories).ToList(): null,
                ImageData = image.ImageData,
                UploadDate = image.UploadDate
            };
        }

        public static IEnumerable<Database.Model.Category> Map(List<Category> categories)
        {
            return categories.Select(Map);
        }
        public static Database.Model.Category Map(Category category)
        {
            return new Database.Model.Category
            {
                Id = category.Id,
                Name = category.Name,
                Tags = MappingHelper.Map(category.Tags).ToList()
            };
        }

        private static IEnumerable<Database.Model.Tags> Map(IEnumerable<Tags> tags)
        {
            return tags.Select(Map);
        }

        private static Database.Model.Tags Map(Tags tags)
        {
            return new Database.Model.Tags
            {
                Id = tags.Id,
                Tag = tags.Tag
            };
        }

        public static IEnumerable<Database.Model.Word> Map(IEnumerable<Word> words)
        {
            return words.Select(Map);
        }

        public static IEnumerable<Image> Map(IEnumerable<Database.Model.Image> dbImages)
        {
            return dbImages.Select(Map);
        }
        public static Image Map(Database.Model.Image dbImage)
        {
            return new Image
            {
                Words = dbImage.Words != null ? Map(dbImage.Words).ToList() : new List<Word>(),
                ImageData = dbImage.ImageData,
                Categories = dbImage.Categories != null ? Map(dbImage.Categories).ToList() : new List<Category>(),
                Id = dbImage.Id,
                UploadDate = dbImage.UploadDate
            };
        }

        public static IEnumerable<Category> Map(List<Database.Model.Category> categories)
        {
            return categories.Select(Map);
        }
        public static Category Map(Database.Model.Category category)
        {
            return new Category
            {
                Id = category.Id,
                Tags = MappingHelper.Map(category.Tags).ToList(),
                Name = category.Name
            };
        }

        public static IEnumerable<Tags> Map(IEnumerable<Database.Model.Tags> tags)
        {
            return tags.Select(Map);
        }

        public static Tags Map(Database.Model.Tags tags)
        {
            return new Tags
            {
                Id = tags.Id,
                Tag = tags.Tag
            };
        }

        public static IEnumerable<Database.Model.Category> Map(IEnumerable<Category> categories)
        {
            return categories.Select(Map);
        }

        public static IEnumerable<Category> Map(IEnumerable<Database.Model.Category> dbCategories)
        {
            return dbCategories.Select(Map);
        }
    }
}

