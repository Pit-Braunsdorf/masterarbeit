using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

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
    }
}
