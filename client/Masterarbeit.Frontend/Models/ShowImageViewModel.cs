using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Masterarbeit.Frontend.Models
{
    public class ShowImageViewModel
    {
        public byte[] ImageData { get; set; }
        public List<WordViewModel> Words { get; set; }
    }
}
