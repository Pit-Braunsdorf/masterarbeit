using System.ComponentModel.DataAnnotations.Schema;

namespace Masterarbeit.DatabaseService.Database.Model
{
    public class Tags
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Tag { get; set; }
    }
}