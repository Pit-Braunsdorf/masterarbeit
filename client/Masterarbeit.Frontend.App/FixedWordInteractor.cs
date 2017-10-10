using System;
using System.Collections.Generic;
using Masterarbeit.Frontend.MAML.DatabaseAccess;
using Masterarbeit.Shared.Contracts;

namespace Masterarbeit.Frontend.App
{
    public class FixedWordInteractor
    {
        private readonly FixedWordApiClient _apiClient;

        public FixedWordInteractor(FixedWordApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public FixedWord CreateFixedWord(FixedWord fixedWord)
        {
            return _apiClient.Post(fixedWord);
        }

        public IEnumerable<FixedWord> GetFixedWords()
        {
            return _apiClient.Get();
        }

        public void DeleteFixedWord(int id)
        {
            _apiClient.Delete(id);
        }

        public FixedWord UpdateFixedWord(FixedWord fixedWord)
        {
            return _apiClient.Put(fixedWord);
        }
    }
}
