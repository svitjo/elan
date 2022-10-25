using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElanWaveBookStore.DTO
{
    public class DTOGetUser
    {
        public Guid UserAccountID { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public Boolean isDeleted { get; set; }
    }
}
