using System;
using System.Collections.Generic;
using Masterarbeit.MAML.DatabaseService.DatabaseAccess;
using Masterarbeit.Shared.Contracts;

namespace Masterarbeit.MAML.DatabaseService.App
{
    /// <summary>
    /// 
    /// </summary>
    public class FixedWordInteractor
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly FixedWordProvider _fixedWordProvider;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fixedWordProvider"></param>
        public FixedWordInteractor(FixedWordProvider fixedWordProvider)
        {
            _fixedWordProvider = fixedWordProvider;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FixedWord GetFixedWord(int id)
        {
            return _fixedWordProvider.Get(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FixedWord> GetFixedWords()
        {
            return _fixedWordProvider.Get();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fixedWord"></param>
        /// <returns></returns>
        public FixedWord CreateFixedWord(FixedWord fixedWord)
        {
            return _fixedWordProvider.Create(fixedWord);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fixedWords"></param>
        /// <returns></returns>
        public IEnumerable<FixedWord> CreateFixedWords(IEnumerable<FixedWord> fixedWords)
        {
            return _fixedWordProvider.Create(fixedWords);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fixedWord"></param>
        /// <returns></returns>
        public FixedWord UpdateFixedWord(FixedWord fixedWord)
        {
            return _fixedWordProvider.Update(fixedWord);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fixedWords"></param>
        /// <returns></returns>
        public IEnumerable<FixedWord> UpdateFixedWords(IEnumerable<FixedWord> fixedWords)
        {
            return _fixedWordProvider.Update(fixedWords);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void DeleteFixedWord(int id)
        {
            _fixedWordProvider.Delete(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fixedWord"></param>
        public void DeleteFixedWord(FixedWord fixedWord)
        {
            _fixedWordProvider.Delete(fixedWord);
        }

        /// <summary>
        /// 
        /// 
        /// </summary>
        /// <param name="fixedWords"></param>
        public void DeleteFixedWords(IEnumerable<FixedWord> fixedWords)
        {
            _fixedWordProvider.Delete(fixedWords);
        }

        /// <summary>
        /// 
        /// 
        /// </summary>
        /// <param name="fixedWords"></param>
        public void DeleteFixedWords(IEnumerable<int> ids)
        {
            _fixedWordProvider.Delete(ids);
        }
    }
}
