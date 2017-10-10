using System.Collections.Generic;

namespace Masterarbeit.Shared.Contracts
{
    public class OCRResult
    {
        public string Orientation { get; set; }
        public string Language { get; set; }
        public List<Region> Regions { get; set; }
        public long TextAngle { get; set; }
    }
}
