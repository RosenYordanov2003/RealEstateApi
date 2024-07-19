namespace RealEstate.Controllers.V1
{
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MediatR;
    using Core.Models.Subscription;
    using Core.Queries.Users;
    using Extensions;
    using Responses.Properties;
    using Core.Commands.Subscription;

    [Route("api/subscription")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SubscriptionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SubscriptionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] SubscriptionModel model)
        {
            string username = User.GetUserName();

            if (string.IsNullOrWhiteSpace(username))
            {
                return NotFound(new PropertyBaseResponseModel(false, "User does not exist"));
            }

            Guid userId = await _mediator.Send(new GetUserIdQuery(username));

            if (await _mediator.Send(new CheckIfUserAlreadyHasSubscriptionQuery(userId, model.SubscriptionCategory)))
            {
                return BadRequest(new PropertyBaseResponseModel(false, "User already has a subscription for this category"));    
            }

            await _mediator.Send(new CreateSubscriptionCommand(model, userId));

            return Ok();
        }
    }
}
