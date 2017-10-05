using System.Collections.Generic;
using System.Linq;
using Masterarbeit.Shared.Contracts;
using Masterarbeit.DatabaseService.Database;
using Masterarbeit.DatabaseService.DatabaseAccess.Helper;
using System;
using System.Data.Common;

namespace Masterarbeit.DatabaseService.DatabaseAccess
{
    public class FixedWordProvider
    {
        private readonly DatabaseContext _databaseContext;

        public FixedWordProvider(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void CreateFixedWords(IEnumerable<FixedWord> fixedWords)
        {
            foreach (var fixedWord in fixedWords)
            {
                CreateFixedWord(fixedWord);
            }
        }

        public FixedWord CreateFixedWord(FixedWord fixedWord)
        {
            var dbFixedWord = MappingHelper.Map(fixedWord);
            _databaseContext.FixedWords.Add(dbFixedWord);
            _databaseContext.SaveChanges();
            return MappingHelper.Map(dbFixedWord);
        }

        public void UpdateFixedWords(IEnumerable<FixedWord> fixedWords)
        {
            foreach (var fixedWord in fixedWords)
            {
                UpdateFixedWord(fixedWord);
            }
        }

        public FixedWord UpdateFixedWord(FixedWord fixedWord)
        {
            var dbFixedWord = _databaseContext.FixedWords.Single(x => x.Id == fixedWord.Id);
            dbFixedWord.Word = fixedWord.Word;
            dbFixedWord.Language = fixedWord.Language;
            dbFixedWord.Updated = DateTime.Now;

            _databaseContext.FixedWords.Attach(dbFixedWord);
            _databaseContext.SaveChanges();
            return MappingHelper.Map(dbFixedWord);
        }

        public void DeleteFixedWord(int id)
        {
            var dbFixedWord = _databaseContext.FixedWords.Single(x => x.Id == id);
            _databaseContext.FixedWords.Remove(dbFixedWord);
            _databaseContext.SaveChanges();
        }

        public void DeleteFixedWords(IEnumerable<FixedWord> fixedWords)
        {
            foreach (var fixedWord in fixedWords)
            {
                DeleteFixedWord(fixedWord);
            }
        }

        public void DeleteFixedWord(FixedWord fixedWord)
        {
            var dbFixedWord = MappingHelper.Map(fixedWord);
            _databaseContext.FixedWords.Remove(dbFixedWord);
            _databaseContext.SaveChanges();
        }

        public FixedWord GetFixedWord(int id)
        {
            var dbFixedWord = _databaseContext.FixedWords.Single(x => x.Id == id);
            var fixedWord = MappingHelper.Map(dbFixedWord);
            return fixedWord;
        }

        public IEnumerable<FixedWord> GetAll()
        {
            var dbFixedWords = _databaseContext.FixedWords.AsEnumerable();
            var fixedWords = MappingHelper.Map(dbFixedWords);
            return fixedWords;
        }
    }
}
