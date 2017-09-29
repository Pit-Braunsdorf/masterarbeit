using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Masterarbeit.DatabaseService.Contracts;
using Masterarbeit.DatabaseService.Database;
using Masterarbeit.DatabaseService.DatabaseAccess.Helper;

namespace Masterarbeit.DatabaseService.DatabaseAccess
{
    public class WordProvider
    {
        private readonly DatabaseContext _databaseContext;

        public WordProvider(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public Word Get(int id)
        {
            var dbWord = _databaseContext.Words.Single(x => x.Id == id);
            var word = MappingHelper.Map(dbWord);
            return word;
        }

        public IEnumerable<Word> Get()
        {
            var dbWords = _databaseContext.Words.AsEnumerable();
            var words = MappingHelper.Map(dbWords);
            return words;
        }

        public void Create(Word word)
        {
            var dbWord = MappingHelper.Map(word);
            _databaseContext.Words.Add(dbWord);
            _databaseContext.SaveChanges();
        }

        public void Update(Word word)
        {
            var dbWord = MappingHelper.Map(word);
            _databaseContext.Words.Attach(dbWord);
            _databaseContext.SaveChanges();
        }

        public void Delete(Word word)
        {
            var dbWord = MappingHelper.Map(word);
            _databaseContext.Words.Remove(dbWord);
        }
    }
}
