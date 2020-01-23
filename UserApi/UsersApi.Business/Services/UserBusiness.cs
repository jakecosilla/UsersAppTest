using UsersApi.Business.Interfaces;
using UsersApi.Data.Entities;
using UsersApi.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UsersApi.Business.Models;
using AutoMapper;

namespace UsersApi.Business.Services
{

    public class UserBusiness : IUserBusiness
    {
        private readonly IUserData _iUserData;
        private readonly IMapper _iMapper;
        public UserBusiness(IUserData iUserData, IMapper iMapper)
        {
            _iUserData = iUserData;
            _iMapper = iMapper;
        }
        public async Task<IEnumerable<User>> GetUsers(CancellationToken cancellationToken)
        {
            var userEntities = await _iUserData.GetUsers(cancellationToken);
            var users = _iMapper.Map<List<User>>(userEntities);

            return users;
        }

        public async Task<User> GetUser(int id, CancellationToken cancellationToken)
        {
            var userEntity = await _iUserData.GetUser(id, cancellationToken);
            var user = _iMapper.Map<User>(userEntity);

            return user;
        }

        public async Task<User> CreateUser(User user, CancellationToken cancellationToken)
        {
            var userEntity = _iMapper.Map<UserEntity>(user);

            await _iUserData.CreateUser(userEntity, cancellationToken);

            var result = _iMapper.Map<User>(userEntity);

            return result;
        }

        public async Task<User> UpdateUser(int id, User user, CancellationToken cancellationToken)
        {
            var userEntity = _iMapper.Map<UserEntity>(user);
            userEntity.Id = id;

            await _iUserData.UpdateUser(userEntity, cancellationToken);

            var result = _iMapper.Map<User>(userEntity);

            return result;
        }
        public async Task<User> DeleteUser(int id, CancellationToken cancellationToken)
        {
            var userEntity = await _iUserData.DeleteUser(id, cancellationToken);

            var result = _iMapper.Map<User>(userEntity);

            return result;
        }
    }
}
