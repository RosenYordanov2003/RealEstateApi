﻿namespace RealEstate.Controllers
{
    using System.Text;
    using System.Security.Claims;
    using System.IdentityModel.Tokens.Jwt;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.IdentityModel.Tokens;
    using Responses.Account;
    using Data.Data.Models;
    using Core.Models.Account;
    using RealEstate.Core.Contracts;

    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IConfiguration _config;
        private UserManager<User> _userManager;
        private IAccountService _accountService;
        public AccountController(IConfiguration config, UserManager<User> userManager, 
            IAccountService accountService)
        {
            _config = config;
            _userManager = userManager;
            _accountService = accountService;
        }
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                List<string> errors = ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage).ToList();
                return BadRequest(new RegisterResponseModel(false, string.Join(" ", errors)));
            }
            if (await _userManager.FindByEmailAsync(model.Email) != null)
            {
                return BadRequest(new RegisterResponseModel(false, "User with this email already exist's"));
            }
            if (await _userManager.FindByNameAsync(model.UserName) != null)
            {
                return BadRequest(new RegisterResponseModel(false, "User with this username already exist's"));
            }
            User user = new User()
            {
                Email = model.Email,
                UserName = model.UserName,
            };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(new RegisterResponseModel(false, string.Join(" ", errors)));
            }
            return Ok(new RegisterResponseModel(true));
        }
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            User user = await _userManager.FindByNameAsync(model.Username);
            if(user == null)
            {
                return NotFound(new LoginResponseModel(false, null, "User not found"));
            }
            if(!await _userManager.CheckPasswordAsync(user, model.Password))
            {
                return BadRequest(new LoginResponseModel(false, null, "Wrong Password!"));
            }
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var issuer = _config.GetSection("Jwt:ValidIssuer").Get<string>();
            var audience = _config.GetSection("Jwt:ValidAudience").Get<string>();

            var token = await  _accountService.GenerateJwtTokenAsync(user, securityKey, issuer, audience);

            return Ok(new LoginResponseModel(true, token));
        }
    }
}
