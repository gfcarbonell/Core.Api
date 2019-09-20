using Core.Api.Business.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Api.Security.ViewModels.Response
{
    public class LoginModelResponse : ModelResponse
    {
        public User User { get; set; }
    }
}
