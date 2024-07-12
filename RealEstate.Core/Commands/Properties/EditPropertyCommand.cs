﻿namespace RealEstate.Core.Commands.Properties
{
    using MediatR;
    using Models.Property;
    public record EditPropertyCommand(EditPropertyModel model, Guid id) : IRequest;
   
}
