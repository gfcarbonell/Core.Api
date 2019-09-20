using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Api.Security.ViewModels.Request
{
    public class LoginModelRequest
    {
        [Required]
        [StringLength(30, MinimumLength = 1)]
        public string Username { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 6)]
        public string Password { get; set; }
    }
}
