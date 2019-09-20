using Core.Api.Business.Models.Security;
using Core.Api.Security.ViewModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Api.Security.Mappers
{
    public static class UserMapper
    {
        public static User Map(LoginModelRequest modelRequest)
        {
            return new User()
            {
                Username = modelRequest.Username,
                Password = modelRequest.Password
            };
        }
    }
}
