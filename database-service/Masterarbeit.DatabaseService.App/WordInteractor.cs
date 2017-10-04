using System.Collections.Generic;
using Masterarbeit.Shared.Contracts;
using Masterarbeit.DatabaseService.DatabaseAccess;

namespace Masterarbeit.DatabaseService.App
{
    public class WordInteractor
    {
        private readonly WordProvider _wordProvider;

        public WordInteractor(WordProvider wordProvider)
        {
            _wordProvider = wordProvider;
        }
        public IEnumerable<Word> Get()
        {
            return _wordProvider.Get();
        }

        public Word Get(int id)
        {
            return _wordProvider.Get(id);
        }

        public void Create(Word word)
        {
            _wordProvider.Create(word);
        }

        public void Update(Word word)
        {
            _wordProvider.Update(word);
        }

        public void Delete(int id)
        {
            var word = _wordProvider.Get(id);
            _wordProvider.Delete(word);
        }

        public void Create(IEnumerable<Word> words)
        {
            foreach (var word in words)
            {
                Create(word);
            }
        }

        public void Delete(Word word)
        {
            _wordProvider.Delete(word);
        }

        public void Delete(IEnumerable<Word> words)
        {
            foreach (var word in words)
            {
                _wordProvider.Delete(word);
            }
        }
    }
}
