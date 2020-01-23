using UsersApi.Data.Entities;
using UsersApi.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace UsersApi.Data.Services
{
    public class UserData : IUserData
    {

        private readonly UserDbContext _context;

        public UserData(UserDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserEntity>> GetUsers(CancellationToken cancellationToken)
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<UserEntity> GetUser(int id, CancellationToken cancellationToken)
        {
            var userEntity = await _context.Users.FindAsync(id);

            return userEntity;
        }


        public async Task<UserEntity> CreateUser(UserEntity userEntity, CancellationToken cancellationToken)
        {
            _context.Users.Add(userEntity);
            await _context.SaveChangesAsync();

            return userEntity;
        }

        public async Task<UserEntity> UpdateUser(UserEntity userEntity, CancellationToken cancellationToken)
        {
            _context.Entry(userEntity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return userEntity;
        }

        public async Task<UserEntity> DeleteUser(int id, CancellationToken cancellationToken)
        {
            var userEntity = await _context.Users.FindAsync(id);

            _context.Users.Remove(userEntity);
            await _context.SaveChangesAsync();

            return userEntity;
        }

        private bool UserEntityExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
