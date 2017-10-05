using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Masterarbeit.DatabaseService.Database.Model
{
    public class Word
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ReadWord { get; set; }
        public string CorrectedWord { get; set; }
        [MaxLength(10)]
        public string Language { get; set; }
        public DateTime Inserted { get; set; }
        public DateTime? Updated { get; set; }
    }
}
