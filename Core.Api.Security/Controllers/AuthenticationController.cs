using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Api.Application.Contract.IServices.Security;
using Core.Api.Security.Mappers;
using Core.Api.Security.ViewModels.Request;
using Core.Api.Security.ViewModels.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Core.Api.Security.Controllers
{
    //[Route("api/v1/[controller]")]
    [Route("api/v1/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IHttpContextAccessor IHttpContextAccessor;
        private readonly ILogger<AuthenticationController> ILogger;

        // Services
        private readonly IAuthenticationService IAuthenticationService;

        public AuthenticationController(
            IHttpContextAccessor IHttpContextAccessor,
            IAuthenticationService IAuthenticationService,
            ILogger<AuthenticationController> ILogger
            )
        {
            this.IAuthenticationService = IAuthenticationService;
            this.IHttpContextAccessor = IHttpContextAccessor;
            this.ILogger = ILogger;
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <remarks>
        /// <param name="request"></param>        
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(401)]
        [Produces("application/json", Type = typeof(LoginModelResponse))]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModelRequest request)
        {
            var response = new LoginModelResponse();
            response.UrlApi = HttpContext.Request.Path.Value; // Get URL

            if (request == null)
            {
                response.ErrorMessage = "Request is null";
                response.Success = false;
                return BadRequest(response);
            }
            if (String.IsNullOrEmpty(request.Username))
            {
                response.ErrorMessage = "@Username is null or empty";
                response.Success = false;
                return BadRequest(response);
            }
            if (String.IsNullOrEmpty(request.Password))
            {
                response.ErrorMessage = "@Password is null or empty";
                response.Success = false;
                return BadRequest(response);
            }

            var obj = await this.IAuthenticationService.Login(UserMapper.Map(request));

            if (obj == null)
            {
                response.ErrorMessage = "User not found";
                response.Success = false;
                return NotFound(response);
            }

            // Response Ok
            response.User = obj;
            response.Success = true;
            return Ok(response);
        }
    }
}