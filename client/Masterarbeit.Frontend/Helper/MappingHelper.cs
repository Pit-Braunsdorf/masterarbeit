using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
