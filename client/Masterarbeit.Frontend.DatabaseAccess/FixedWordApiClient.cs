using System;
using System.Collections.Generic;
using System.Text;
using Masterarbeit.Frontend.Contracts;
using Masterarbeit.Shared.Contracts;

namespace Masterarbeit.Frontend.DatabaseAccess
{
    public class FixedWordApiClient
    {
        private readonly WebApiClient _client;

        public FixedWordApiClient(WebApiClient client)
        {
            _client = client;
        }

        public List<FixedWord> Get()
        {
            return _client.Get<List<FixedWord>>("Get");
        }

        public FixedWord Get(int id)
        {
            return _client.Get<FixedWord>("Get", new Dictionary<string, object> {{nameof(id), id}});
        }

        public void Post(FixedWord fixedWord)
        {
            _client.Post<FixedWord>("Post", fixedWord);
        }

        public void Put(FixedWord fixedWord)
        {
            _client.Put("Put", fixedWord);
        }

        public void Delete(int id)
        {
            _client.Delete("Delete", new Dictionary<string, object>{{nameof(id), id}});
        }
    }
}
