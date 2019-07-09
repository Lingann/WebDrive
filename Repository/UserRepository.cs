using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contracts;
using Entities;
using Entities.ExtendedModels;
using Entities.Models;

namespace Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public IEnumerable<User> GetAllUser()
        {
            return FindAll()
                .OrderBy(ow => ow.name)
                .ToList();
        }

        public User GetUserById(int userId)
        {
            return FindByCondition(user => user.id.Equals(userId))
                .DefaultIfEmpty(new User())
                .FirstOrDefault();
        }

        public User GetUser()
        {
            return RepositoryContext.User.FirstOrDefault();
        }

        public void AddUser(User user)
        {
            user.id = 5;
            Create(user);
            Save();
        }

        public UserExtended GetUserWithDetail(int userId)
        {
            return new UserExtended(GetUserById(userId))
            {

            };
        }
    } 
}
