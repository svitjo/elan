using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElanWaveBookStore.DTO
{
    public class DTOBook
    {
        public Guid BookID { get; set; }
        public char ISBN { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string genre { get; set; }
        public Boolean isDeleted { get; set; }
    }
}
