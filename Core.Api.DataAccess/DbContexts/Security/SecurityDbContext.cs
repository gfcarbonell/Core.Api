using Core.Api.DataAccess.Contract.IDbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Api.DataAccess.DbContexts.Security
{
    public class SecurityDbContext : DbContext, ISecurityDbContext
    {
        public SecurityDbContext(DbContextOptions<SecurityDbContext> options) :
               base(options)
        {

        }

        public SecurityDbContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
