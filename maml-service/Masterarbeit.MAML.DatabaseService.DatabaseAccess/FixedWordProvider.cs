using System.Collections.Generic;
using System.Linq;
using Masterarbeit.MAML.DatabaseService.Database;
using Masterarbeit.MAML.DatabaseService.DatabaseAccess.Helper;
using Masterarbeit.Shared.Contracts;
using Masterarbeit.Shared.DabaseAccess;

namespace Masterarbeit.MAML.DatabaseService.DatabaseAccess
{
    public class FixedWordProvider : IProvider<FixedWord>
    {
        private readonly DatabaseContext _databaseContext;

        public FixedWordProvider(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        
        public FixedWord Get(int id)
        {
            var dbFixedWord = _databaseContext.FixedWords.Single(x => x.Id == id);
            return MappingHelper.Map(dbFixedWord);
        }

        public IEnumerable<FixedWord> Get()
        {
            var dbFixedWords = _databaseContext.FixedWords.AsEnumerable();
            return MappingHelper.Map(dbFixedWords);
        }

        public FixedWord Create(FixedWord fixedWord)
        {
            var dbFixedWord = MappingHelper.Map(fixedWord);
            _databaseContext.FixedWords.Add(dbFixedWord);
            _databaseContext.SaveChanges();
            return MappingHelper.Map(dbFixedWord);
        }

        public IEnumerable<FixedWord> Create(IEnumerable<FixedWord> fixedWords)
        {
            var dbFixedWords = MappingHelper.Map(fixedWords).ToList();
            _databaseContext.FixedWords.AddRange(dbFixedWords);
            _databaseContext.SaveChanges();
            return MappingHelper.Map(dbFixedWords);
        }

        public void Delete(int id)
        {
            var dbFixedWord = _databaseContext.FixedWords.Single(x => x.Id == id);
            _databaseContext.FixedWords.Remove(dbFixedWord);
            _databaseContext.SaveChanges();
        }

        public void Delete(FixedWord entity)
        {
            var dbFixedWord = _databaseContext.FixedWords.Single(x => x.Id == entity.Id);
            _databaseContext.FixedWords.Remove(dbFixedWord);
            _databaseContext.SaveChanges();
        }

        public void Delete(IEnumerable<FixedWord> entities)
        {
            var entityIds = entities.Select(x => x.Id);
            var dbFixedWords = _databaseContext.FixedWords.Where(x => entityIds.Contains(x.Id));
            _databaseContext.FixedWords.RemoveRange(dbFixedWords);
            _databaseContext.SaveChanges();
        }

        public void Delete(IEnumerable<int> ids)
        {
            var dbFixedWords = _databaseContext.FixedWords.Where(x => ids.Contains(x.Id));
            _databaseContext.FixedWords.RemoveRange(dbFixedWords);
            _databaseContext.SaveChanges();
        }

        public FixedWord Update(FixedWord entity)
        {
            var dbFixedWord = _databaseContext.FixedWords.Single(x => x.Id == entity.Id);
            UpdateDbFixedWord(ref dbFixedWord, entity);
            _databaseContext.FixedWords.Attach(dbFixedWord);
            _databaseContext.SaveChanges();
            return MappingHelper.Map(dbFixedWord);
        }

        public IEnumerable<FixedWord> Update(IEnumerable<FixedWord> entities)
        {
            return entities.Select(Update);
        }

        private void UpdateDbFixedWord(ref Database.Model.FixedWord dbFixedWord, FixedWord entity)
        {
            dbFixedWord.Count = entity.Count;
            dbFixedWord.FalsePositiveCount = entity.Count;
        }
    }
}
