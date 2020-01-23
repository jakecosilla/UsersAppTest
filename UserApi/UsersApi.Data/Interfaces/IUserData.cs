using UsersApi.Data.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace UsersApi.Data.Interfaces
{
    public interface IUserData
    {
        Task<IEnumerable<UserEntity>> GetUsers(CancellationToken cancellationToken);
        Task<UserEntity> GetUser(int id, CancellationToken cancellationToken);
        Task<UserEntity> CreateUser(UserEntity userEntity, CancellationToken cancellationToken);
        Task<UserEntity> UpdateUser(UserEntity userEntity, CancellationToken cancellationToken);
        Task<UserEntity> DeleteUser(int id, CancellationToken cancellationToken);
    }
}
