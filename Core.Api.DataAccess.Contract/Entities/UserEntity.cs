﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Api.DataAccess.Contract.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
