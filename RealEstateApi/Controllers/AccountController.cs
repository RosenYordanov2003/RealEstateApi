namespace RealEstate.Controllers
{
    using System.Text;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.AspNetCore.Authorization;
    using Responses.Account;
    using Data.Data.Models;
    using Core.Models.Account;
    using Core.Contracts.Account;
    using Core.Contracts.Email;
    using Extensions;
    using Core.Commands.Users;
    using MediatR;

    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IConfiguration _config;
        private UserManager<User> _userManager;
        private IAccountService _accountService;
        private IEmailSender _emailSender;
        private IMediator _mediator;
        public AccountController(IConfiguration config, UserManager<User> userManager,
            IAccountService accountService, IEmailSender emailSender, IMediator mediator)
        {
            _config = config;
            _userManager = userManager;
            _accountService = accountService;
            _emailSender = emailSender;
            _mediator = mediator;
        }
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
            await SendEmailToken(user);

            return Ok(new RegisterResponseModel(true));
        }


        [HttpGet]
        [Route("confirmEmail")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> ConfirmEmail(string emailToken, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.ConfirmEmailAsync(user, emailToken);
            if (!result.Succeeded)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            User user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                return NotFound(new LoginResponseModel(false, null, "Incorrect username or password"));
            }
            if (!await _userManager.CheckPasswordAsync(user, model.Password))
            {
                return BadRequest(new LoginResponseModel(false, null, "Incorrect username or password"));
            }
            bool isEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user);
            if (!isEmailConfirmed)
            {
                await SendEmailToken(user);

                return BadRequest("Email is unconfirmed, please confirm it first");
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var issuer = _config.GetSection("Jwt:ValidIssuer").Get<string>();
            var audience = _config.GetSection("Jwt:ValidAudience").Get<string>();

            var token = await _accountService.GenerateJwtTokenAsync(user, securityKey, issuer, audience);

            return Ok(new LoginResponseModel(true, token));
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("enable2FA")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> EnableTwoFa()
        {
            string userName = User.GetUserName();
            if (string.IsNullOrWhiteSpace(userName))
            {
                return BadRequest();
            }

            await _mediator.Send(new EnableUser2FACommand(userName));

            return Ok();
        }

        private async Task SendEmailToken(User user)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            string confirmationLink = Url.Action("ConfirmEmail", "Account", new { emailToken = token, email = user.Email }, Request.Scheme);
            await _emailSender.SendEmailAsync(user.Email, "Confirm your email", confirmationLink);
        }
    }
}
