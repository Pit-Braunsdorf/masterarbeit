using System;
using System.Collections.Generic;
using Masterarbeit.Shared.Contracts;
using Masterarbeit.DatabaseService.DatabaseAccess;

namespace Masterarbeit.DatabaseService.App
{
    public class FixedWordInteractor
    {
        private readonly FixedWordProvider _fixedWordProvider;

        public FixedWordInteractor(FixedWordProvider fixedWordProvider)
        {
            _fixedWordProvider = fixedWordProvider;
        }

        public FixedWord Create(FixedWord fixedWord)
        {
            return _fixedWordProvider.CreateFixedWord(fixedWord);
        }

        public void Create(IEnumerable<FixedWord> fixedWords)
        {
            _fixedWordProvider.CreateFixedWords(fixedWords);
        }

        public FixedWord Get(int id)
        {
            return _fixedWordProvider.GetFixedWord(id);
        }

        public IEnumerable<FixedWord> Get()
        {
            return _fixedWordProvider.GetAll();
        }

        public FixedWord Update(FixedWord fixedWord)
        {
            return _fixedWordProvider.UpdateFixedWord(fixedWord);
        }

        public void Update(IEnumerable<FixedWord> fixedWords)
        {
            _fixedWordProvider.CreateFixedWords(fixedWords);
        }

        public void Delete(int id)
        {
            _fixedWordProvider.DeleteFixedWord(id);
        }
        public void Delete(FixedWord fixedWord)
        {
            _fixedWordProvider.DeleteFixedWord(fixedWord);
        }

        public void Delete(IEnumerable<FixedWord> fixedWords)
        {
            _fixedWordProvider.DeleteFixedWords(fixedWords);
        }
    }
}
