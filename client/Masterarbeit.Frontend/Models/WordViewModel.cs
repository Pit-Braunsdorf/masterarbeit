using System;

namespace Masterarbeit.Frontend.Models
{
    public class WordViewModel
    {
        public int Id { get; set; }
        public string ReadWord { get; set; }
        public string CorrectedWord { get; set; }
        public string Language { get; set; }
        public DateTime Inserted { get; set; }
        public DateTime? Updated { get; set; }
    }
}