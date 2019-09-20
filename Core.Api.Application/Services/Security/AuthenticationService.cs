using Core.Api.Application.Contract.IServices.Security;
using Core.Api.Business.Models.Security;
using Core.Api.DataAccess.Contract.IRepositories.ISecurity;
using Core.Api.DataAccess.Mappers.Security;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Api.Application.Services.Security
{
    public class AuthenticationService: IAuthenticationService
    {
        private readonly IAuthenticationRepository IAuthenticationRepository;

        public AuthenticationService(IAuthenticationRepository IAuthenticationRepository)
        {
            this.IAuthenticationRepository = IAuthenticationRepository;
        }

        public Task<User> Add(User element)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(User element)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exist(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exist(User element)
        {
            throw new NotImplementedException();
        }

        public Task<User> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> Get(User element)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<User> Login(User element)
        {
            var obj = await this.IAuthenticationRepository.Login(UserMapper.Map(element));
            if (obj == null)
            {
                return null;
            }
            return UserMapper.Map(obj);
        }

        public Task<User> Logout(User element)
        {
            throw new NotImplementedException();
        }

        public Task<User> Register(User element)
        {
            throw new NotImplementedException();
        }

        public Task<User> Update(int id, User element)
        {
            throw new NotImplementedException();
        }

        public Task<User> Update(User element)
        {
            throw new NotImplementedException();
        }
    }
}
