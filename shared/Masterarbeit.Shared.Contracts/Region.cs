using System.Collections.Generic;

namespace Masterarbeit.Shared.Contracts
{
    public class Region
    {
        public string BoundingBox { get; set; }
        public List<Line> Lines { get; set; }
    }
}