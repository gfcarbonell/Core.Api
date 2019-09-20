using Core.Api.Business.Models.Security;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Api.Application.Contract.IServices.Security
{
    public interface IAuthenticationService : IService<User>
    {
        Task<User> Login(User element);
        Task<User> Logout(User element);
        Task<User> Register(User element);
    }
}
