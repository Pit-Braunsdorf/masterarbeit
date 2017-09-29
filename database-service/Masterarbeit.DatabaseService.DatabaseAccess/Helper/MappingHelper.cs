﻿using System.Collections.Generic;
using System.Linq;
using Masterarbeit.DatabaseService.Contracts;

namespace Masterarbeit.DatabaseService.DatabaseAccess.Helper
{
    public static class MappingHelper
    {
        public static Database.Model.FixedWord Map(Contracts.FixedWord fixedWord)
        {
            return new Database.Model.FixedWord
            {
                Id = fixedWord.Id,
                Inserted = fixedWord.Inserted,
                Updated = fixedWord.Updated,
                Language = fixedWord.Language,
                Word = fixedWord.Word
            };
        }

        public static Contracts.FixedWord Map(Database.Model.FixedWord dbFixedWord)
        {
            return new Contracts.FixedWord
            {
                Id = dbFixedWord.Id,
                Inserted = dbFixedWord.Inserted,
                Updated = dbFixedWord.Updated,
                Language = dbFixedWord.Language,
                Word = dbFixedWord.Word
            };
        }

        public static IEnumerable<Contracts.FixedWord> Map(IEnumerable<Database.Model.FixedWord> dbFixedWords)
        {
            return dbFixedWords.Select(Map);
        }

        public static Word Map(Database.Model.Word dbFixedWords)
        {
            return new Contracts.Word
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
                Words = Map(image.Words).ToList(),
                Categories = Map(image.Categories).ToList(),
                BlobUri = image.BlobUri,
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
                Tags = category.Tags
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
                Words = Map(dbImage.Words).ToList(),
                BlobUri = dbImage.BlobUri,
                Categories = Map(dbImage.Categories).ToList(),
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
                Tags = category.Tags,
                Name = category.Name
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

