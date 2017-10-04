using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Masterarbeit.DatabaseService.Database.Model
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Tags> Tags { get; set; }
    }
}