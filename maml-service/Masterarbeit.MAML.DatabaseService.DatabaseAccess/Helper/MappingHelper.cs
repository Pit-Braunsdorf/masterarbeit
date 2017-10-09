using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Masterarbeit.Shared.Contracts;

namespace Masterarbeit.MAML.DatabaseService.DatabaseAccess.Helper
{
    class MappingHelper
    {
        public static FixedWord Map(Database.Model.FixedWord dbFixedWord)
        {
            return new FixedWord
            {
                Id = dbFixedWord.Id,
                Count = dbFixedWord.Count,
                FalsePositiveCount = dbFixedWord.FalsePositiveCount,
                Language = dbFixedWord.Language,
                Word = dbFixedWord.Word,
                CreateDate = dbFixedWord.CreateDate
            };
        }

        public static Database.Model.FixedWord Map(FixedWord fixedWord)
        {
            return new Database.Model.FixedWord
            {
                Id = fixedWord.Id,
                Count = fixedWord.Count,
                FalsePositiveCount = fixedWord.FalsePositiveCount,
                Language = fixedWord.Language,
                Word = fixedWord.Word,
                CreateDate = fixedWord.CreateDate
            };
        }

        public static IEnumerable<Database.Model.FixedWord> Map(IEnumerable<FixedWord> fixedWords)
        {
            return fixedWords.Select(Map);
        }

        public static IEnumerable<FixedWord> Map(IEnumerable<Database.Model.FixedWord> dbFixedWords)
        {
            return dbFixedWords.Select(Map);
        }
    }
}
