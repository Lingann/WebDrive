using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;
using Entities.ExtendedModels;
namespace Contracts
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        IEnumerable<User> GetAllUser();
        User GetUserById(int userId);
        User GetUser();
        void AddUser(User user);
        UserExtended GetUserWithDetail(int userId);

    }
}
