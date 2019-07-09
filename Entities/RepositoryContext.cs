using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
namespace Entities
{
    // Database实体配置
    public class RepositoryContext :DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options){

        }

        public DbSet<User> User { get; set; }
    }
}
