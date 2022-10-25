using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ElanWaveBookStore.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid BookID { get; set; }
        public string ISBN { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string genre { get; set; }
        public Boolean isDeleted { get; set; }
    }
}
