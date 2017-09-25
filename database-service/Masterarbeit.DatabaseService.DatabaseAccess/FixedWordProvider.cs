using System.Collections.Generic;
using System.Linq;
using Masterarbeit.DatabaseService.Contracts;
using Masterarbeit.DatabaseService.Database;
using Masterarbeit.DatabaseService.DatabaseAccess.Helper;

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

        public void CreateFixedWord(FixedWord fixedWord)
        {
            var dbFixedWord = MappingHelper.Map(fixedWord);
            _databaseContext.FixedWords.Add(dbFixedWord);
            _databaseContext.SaveChanges();
        }

        public void UpdateFixedWords(IEnumerable<FixedWord> fixedWords)
        {
            foreach (var fixedWord in fixedWords)
            {
                UpdateFixedWord(fixedWord);
            }
        }

        public void UpdateFixedWord(FixedWord fixedWord)
        {
            var dbFixedWord = MappingHelper.Map(fixedWord);
            _databaseContext.FixedWords.Attach(dbFixedWord);
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
            var dbFixedWords = _databaseContext.FixedWords;
            var fixedWords = MappingHelper.Map(dbFixedWords);
            return fixedWords;
        }
    }
}
