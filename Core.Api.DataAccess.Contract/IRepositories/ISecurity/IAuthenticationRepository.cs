using Core.Api.DataAccess.Contract.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Api.DataAccess.Contract.IRepositories.ISecurity
{
    public interface IAuthenticationRepository: IRepository<UserEntity>
    {
        Task<UserEntity> Login(UserEntity entity);
        Task<UserEntity> Logout(UserEntity entity);
        Task<UserEntity> Register(UserEntity entity);
    }
}
