using Core.Api.Business.Models.Security;
using Core.Api.DataAccess.Contract.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Api.DataAccess.Mappers.Security
{
    public class UserMapper
    {
        public static UserEntity Map(User dto)
        {
            return new UserEntity()
            {
                Username = dto.Username,
                Password = dto.Password,
            };
        }

        public static User Map(UserEntity dto)
        {
            return new User()
            {
                Username = dto.Username,
                Password = dto.Password,
            };
        }
    }
}
