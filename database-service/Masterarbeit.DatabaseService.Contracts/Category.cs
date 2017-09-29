using System.Collections.Generic;

namespace Masterarbeit.DatabaseService.Contracts
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Tags { get; set; }
    }
}