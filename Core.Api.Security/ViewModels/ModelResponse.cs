using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Api.Security.ViewModels
{
    public abstract class ModelResponse
    {
        public string UrlApi { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public bool Success { get; set; }
    }
}
