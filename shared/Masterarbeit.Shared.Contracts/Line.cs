using System.Collections.Generic;

namespace Masterarbeit.Shared.Contracts
{
    public class Line
    {
        public string BoundingBox { get; set; }
        public List<OCRWord> Words { get; set; }
    }
}