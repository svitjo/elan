using ElanWaveBookStore.DTO;
using ElanWaveBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElanWaveBookStore.Services
{
    public interface IUserService
    {
        Task<ServiceResponse<List<DTOGetUser>>> GetAllUsers();
        Task<ServiceResponse<DTOGetUser>> getUserById(Guid id);
        Task<ServiceResponse<List<DTOGetUser>>> addUser(DTOAddUser newUser);
    }
}
