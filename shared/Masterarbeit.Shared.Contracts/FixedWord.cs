using System;

namespace Masterarbeit.Shared.Contracts
{
    public class FixedWord
    {
        public int Id { get; set; }
        public string Word { get; set; }
        public string Language { get; set; }
        public int Count { get; set; }
        public int FalsePositiveCount { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
