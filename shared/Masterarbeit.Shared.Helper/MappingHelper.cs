using System;
using System.Collections.Generic;
using System.Linq;
using Masterarbeit.Shared.Contracts;

namespace Masterarbeit.Shared.Helper
{
    public static class MappingHelper
    {
        public static Word Map(OCRWord ocrWord, string recognizedLanguage)
        {
            return new Word
            {
                Language = recognizedLanguage,
                ReadWord = ocrWord.Text,
                Inserted = DateTime.Now
            };
        }

        public static IEnumerable<Word> Map(IEnumerable<OCRWord> ocrWords, string recognizedLanguage)
        {
            return ocrWords.Select(x => Map(x, recognizedLanguage));
        }
    }
}

