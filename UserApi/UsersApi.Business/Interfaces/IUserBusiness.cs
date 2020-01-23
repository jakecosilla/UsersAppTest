using UsersApi.Data.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UsersApi.Business.Models;

namespace UsersApi.Business.Interfaces
{
    public interface IUserBusiness
    {
        Task<IEnumerable<User>> GetUsers(CancellationToken cancellationToken);
        Task<User> GetUser(int id, CancellationToken cancellationToken);
        Task<User> CreateUser(User user, CancellationToken cancellationToken);
        Task<User> UpdateUser(int id, User user, CancellationToken cancellationToken);
        Task<User> DeleteUser(int id, CancellationToken cancellationToken);
    }
}
