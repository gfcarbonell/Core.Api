using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Api.DataAccess.Contract.Entities;
using Core.Api.DataAccess.Contract.IDbContexts;
using Core.Api.DataAccess.Contract.IRepositories.ISecurity;
using Microsoft.EntityFrameworkCore;

namespace Core.Api.DataAccess.Repositories.Security
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly ISecurityDbContext ISecurityDbContext;

        public AuthenticationRepository(ISecurityDbContext ISecurityDbContext)
        {
            this.ISecurityDbContext = ISecurityDbContext;
        }

        public Task<UserEntity> Add(UserEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(UserEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exist(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exist(UserEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserEntity>> Get(UserEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<UserEntity> Login(UserEntity entity)
        {
            using (IDbConnection conn = ISecurityDbContext.Database.GetDbConnection())
            {
                try
                {
                    SqlParameter[] parameter = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@username",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Direction = System.Data.ParameterDirection.Input,
                            IsNullable = false,
                            Value = entity.Username,
                        },

                        new SqlParameter() {
                            ParameterName = "@password",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Direction = System.Data.ParameterDirection.Input,
                            IsNullable = false,
                            Value = entity.Password
                        },
                        new SqlParameter() {
                            ParameterName = "@error_return",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Output,
                            IsNullable = true,
                            Size = 5215585
                        },
                        new SqlParameter() {
                            ParameterName = "@message_return",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Direction = System.Data.ParameterDirection.Output,
                            IsNullable = true,
                            Size = 5215585
                        },
                    };

                    var data = await ISecurityDbContext.Database.ExecuteSqlCommandAsync(@"[dbo].[USP_LOGIN] 
                                                @username, 
                                                @password, 
                                                @error_return output, 
                                                @message_return output",
                                                parameter);

                    var error_return = (int)parameter[2].Value;
                    var message_return = (string)parameter[3].Value;

                    if(error_return != 0)
                    {
                        return null;
                    }
                }

                catch (Exception ex)
                {
                    throw ex;
                }

                return entity;
            }

        }

        public Task<UserEntity> Logout(UserEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity> Register(UserEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity> Update(int id, UserEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity> Update(UserEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
