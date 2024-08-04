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

    [Route("api/subscriptions")]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] SubscriptionModel model)
        {
            if (string.IsNullOrWhiteSpace(User.GetUserName()))
            {
                return NotFound(new PropertyBaseResponseModel(false, "User does not exist"));
            }

            Guid userId = await _mediator.Send(new GetUserIdQuery(User.GetUserName()));

            if (await _mediator.Send(new CheckIfUserAlreadyHasSubscriptionQuery(userId, model.SubscriptionCategoryId)))
            {
                return BadRequest(new PropertyBaseResponseModel(false, "User already has a subscription for this category"));
            }

            await _mediator.Send(new CreateSubscriptionCommand(model, userId));

            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Unsubscribe([FromBody] SubscriptionModel model)
        {
            if (string.IsNullOrWhiteSpace(User.GetUserName()))
            {
                return NotFound(new PropertyBaseResponseModel(false, "User does not exist"));
            }

            Guid userId = await _mediator.Send(new GetUserIdQuery(User.GetUserName()));

            if (!await _mediator.Send(new CheckIfUserAlreadyHasSubscriptionQuery(userId, model.SubscriptionCategoryId)))
            {
                return BadRequest(new PropertyBaseResponseModel(false, "User doesn't have a subscription for this category"));
            }

            await _mediator.Send(new RemoveSubscriptionCommand(userId, model.SubscriptionCategoryId));

            return Ok(new PropertyBaseResponseModel(true, null));
        }
    }
}
