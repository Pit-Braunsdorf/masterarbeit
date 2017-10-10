using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Masterarbeit.DatabaseService.Database.Model
{
    public class Image
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime UploadDate { get; set; }
        public List<Word> Words { get; set; }
        public List<Category> Categories { get; set; }
        public byte[] ImageData { get; set; }
    }
}
