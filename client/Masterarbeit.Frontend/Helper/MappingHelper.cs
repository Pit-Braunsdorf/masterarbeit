using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Masterarbeit.Frontend.Models;
using Masterarbeit.Shared.Contracts;
using Microsoft.CodeAnalysis;

namespace Masterarbeit.Frontend.Helper
{
    public class MappingHelper
    {
        public static ShowFixedWordsViewModel Map(IEnumerable<FixedWord> fixedWords)
        {
            var result = new List<FixedWordViewModel>();

            foreach (var fixedWord in fixedWords)
            {
                result.Add(Map(fixedWord));
            }

            return new ShowFixedWordsViewModel
            {
                FixedWords = result
            };
        }

        public static FixedWordViewModel Map(FixedWord fixedWord)
        {
            return new FixedWordViewModel
            {
                Id = fixedWord.Id,
                Word = fixedWord.Word,
                Language = fixedWord.Language,
            };
        }

        internal static ViewImageViewModel Map(List<Image> images, int count)
        {
            return new ViewImageViewModel
            {
                Count = count,
                Images = images != null ? Map(images) : new List<ImageViewModel>()
            };
        }

        private static List<ImageViewModel> Map(List<Image> images)
        {
            return images.Select(Map).ToList();
        }

        public static ImageViewModel Map(Image image)
        {
            return new ImageViewModel
            {
                Id = image.Id,
                ImageData = image.ImageData
            };
        }

        public static ShowImageViewModel MapImageToShowImageViewModel(Image image, IEnumerable<Word> words)
        {
            return new ShowImageViewModel
            {
                ImageData = image.ImageData,
                Words = Map(words)
            };
        }

        private static List<WordViewModel> Map(IEnumerable<Word> words)
        {
            if(words == null || !words.Any() ) return new List<WordViewModel>();

            return words.Select(Map).ToList();
        }

        private static WordViewModel Map(Word word)
        {
            return new WordViewModel
            {
                Id = word.Id,
                CorrectedWord = word.CorrectedWord,
                Inserted = word.Inserted,
                Language = word.Language,
                ReadWord = word.ReadWord,
                Updated = word.Updated
            };
        }
    }
}
