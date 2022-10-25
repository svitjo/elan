using AutoMapper;
using ElanWaveBookStore.Data;
using ElanWaveBookStore.DTO;
using ElanWaveBookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElanWaveBookStore.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;

        private readonly DataContext context;

        public UserService(IMapper mapper, DataContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        public async Task<ServiceResponse<List<DTOGetUser>>> addUser(DTOAddUser newUser)
        {
            var serviceResponse = new ServiceResponse<List<DTOGetUser>>();
            User user = mapper.Map<User>(newUser);
            context.Users.Add(user);
            await context.SaveChangesAsync();
            serviceResponse.Data = await context.Users.Select(u => mapper.Map<DTOGetUser>(u)).ToListAsync();
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<DTOGetUser>>> GetAllUsers()
        {
            var serviceResponse = new ServiceResponse<List<DTOGetUser>>();
            var dbUsers = await context.Users.ToListAsync();
            serviceResponse.Data = dbUsers.Select(u => mapper.Map<DTOGetUser>(u)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<DTOGetUser>> getUserById(Guid id)
        {
            var serviceResponse = new ServiceResponse<DTOGetUser>();
            var dbUser = await context.Users.FirstOrDefaultAsync(u => u.UserAccountID == id);
            serviceResponse.Data = mapper.Map<DTOGetUser>(dbUser);
            return serviceResponse;
        }

    }
}
