using System;

namespace Masterarbeit.Frontend.Models
{
    public class FixedWordViewModel
    {
        public int Id { get; set; }
        public string Word { get; set; }
        public string Language { get; set; }
        public DateTime Inserted { get; set; }
        public DateTime? Updated { get; set; }
    }
}