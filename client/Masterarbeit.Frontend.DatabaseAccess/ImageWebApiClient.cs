using System;
using System.Collections.Generic;
using System.Text;
using Masterarbeit.Shared.Contracts;

namespace Masterarbeit.Frontend.DatabaseAccess
{
    public class ImageWebApiClient
    {
        private readonly WebApiClient _client;
        private readonly string _controller = "image";

        public ImageWebApiClient(WebApiClient client)
        {
            _client = client;
        }

        public List<Image> Get()
        {
            return _client.Get<List<Image>>(_controller);
        }

        public Image Get(int id)
        {
            return _client.Get<Image>(_controller, new Dictionary<string, object> { { nameof(id), id } });
        }

        public Image Post(Image image)
        {
            return _client.Post<Image>(_controller, image);
        }

        public Image Put(Image Image)
        {
            return _client.Put<Image>(_controller, Image);
        }

        public void Delete(int id)
        {
            _client.Delete(_controller, new Dictionary<string, object> { { nameof(id), id } });
        }

    }
}
