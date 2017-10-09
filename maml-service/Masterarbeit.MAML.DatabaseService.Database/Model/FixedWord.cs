using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Remotion.Linq.Parsing.Structure.IntermediateModel;

namespace Masterarbeit.MAML.DatabaseService.Database.Model
{
    public class FixedWord
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Word { get; set; }
        public string Language { get; set; }
        public int Count { get; set; }
        public int FalsePositiveCount { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;

    }
}
