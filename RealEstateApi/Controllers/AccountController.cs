namespace RealEstate.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using RealEstate.Core.Models.Account;
    using RealEstate.Data.Data.Models;
    using RealEstate.Responses;

    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IConfiguration _config;
        private UserManager<User> _userManager;
        public AccountController(IConfiguration config, UserManager<User> userManager)
        {
            _config = config;
            _userManager = userManager;
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
    }
}
