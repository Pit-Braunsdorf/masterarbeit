using System.Collections.Generic;

namespace Masterarbeit.Shared.Contracts
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Tags> Tags { get; set; }
    }
}