﻿using L2code.Manoelcaixas.Apirest.TokenServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace L2code.Manoelcaixas.Apirest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService;

        public AuthController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("token")]
        public IActionResult GenerateToken([FromBody] L2code.Manoelcaixas.Apirest.TokenServices.LoginRequest request)
        {
            if (request.UserName == "string" && request.Password == "string")
            {
                var token = _tokenService.GenerateToken(request.UserName);
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }

        [HttpPost("revoke")]
        public IActionResult RevokeToken([FromBody] RevokeTokenRequest request)
        {
            _tokenService.RevokeToken(request.Token);
            return Ok($"Token Revoked: '{request.Token}'");
        }

    }

    
}