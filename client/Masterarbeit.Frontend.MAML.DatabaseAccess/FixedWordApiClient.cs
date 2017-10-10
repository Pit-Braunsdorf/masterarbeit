using System.Collections.Generic;
using Masterarbeit.Shared.Contracts;

namespace Masterarbeit.Frontend.MAML.DatabaseAccess
{
    public class FixedWordApiClient
    {
        private readonly WebApiClient _client;
        private readonly string _controller = "fixedword";

        public FixedWordApiClient(WebApiClient client)
        {
            _client = client;
        }

        public List<FixedWord> Get()
        {
            return _client.Get<List<FixedWord>>(_controller);
        }

        public FixedWord Get(int id)
        {
            return _client.Get<FixedWord>(_controller, new Dictionary<string, object> {{nameof(id), id}});
        }

        public FixedWord Post(FixedWord fixedWord)
        {
            return _client.Post<FixedWord>(_controller, fixedWord);
        }

        public FixedWord Put(FixedWord fixedWord)
        {
            return _client.Put<FixedWord>(_controller, fixedWord);
        }

        public void Delete(int id)
        {
            _client.Delete(_controller, new Dictionary<string, object>{{nameof(id), id}});
        }
    }
}
