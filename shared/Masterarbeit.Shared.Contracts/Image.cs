using System;
using System.Collections.Generic;

namespace Masterarbeit.Shared.Contracts
{
    public class Image
    {
        public int Id { get; set; }
        public DateTime UploadDate { get; set; }
        public List<Word> Words { get; set; }
        public List<Category> Categories { get; set; }
        public string BlobUri { get; set; }
    }
}
