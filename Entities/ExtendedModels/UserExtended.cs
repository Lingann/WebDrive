using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;
namespace Entities.ExtendedModels
{
    public class UserExtended
    {
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string email { get; set; }
        public DateTime date { get; set; }

        public UserExtended()
        {

        }

        public UserExtended(User user)
        {
            id = user.id;
            name = user.name;
            age = user.age;
            email = user.email;
            date = user.date;
        }
    }
}
