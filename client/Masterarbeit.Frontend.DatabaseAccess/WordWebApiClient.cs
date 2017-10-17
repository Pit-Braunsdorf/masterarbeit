using System;
using System.Collections.Generic;
using System.Text;
using Masterarbeit.Shared.Contracts;

namespace Masterarbeit.Frontend.DatabaseAccess
{
    public class WordWebApiClient
    {
        private readonly WebApiClient _client;
        private readonly string _controller = "word";

        public WordWebApiClient(WebApiClient client)
        {
            _client = client;
        }

        public List<Word> Get()
        {
            return _client.Get<List<Word>>(_controller);
        }

        public Word Get(int id)
        {
            return _client.Get<Word>(_controller, new Dictionary<string, object> { { nameof(id), id } });
        }

        public Word Post(Word image)
        {
            return _client.Post<Word>(_controller, image);
        }

        public Word Put(Word Image)
        {
            return _client.Put<Word>(_controller, Image);
        }

        public void Delete(int id)
        {
            _client.Delete(_controller, new Dictionary<string, object> { { nameof(id), id } });
        }

        public IEnumerable<Word> GetWordsForImage(int imageId)
        {
            return _client.Get<IEnumerable<Word>>("word/GetWordsForImage", new Dictionary<string, object> { { nameof(imageId), imageId } });
        }

    }
}
