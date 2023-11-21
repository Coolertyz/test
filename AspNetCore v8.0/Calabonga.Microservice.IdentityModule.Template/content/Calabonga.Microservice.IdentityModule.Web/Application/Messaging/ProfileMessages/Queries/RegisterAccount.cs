﻿using Calabonga.Microservice.IdentityModule.Web.Application.Messaging.ProfileMessages.ViewModels;
using Calabonga.Microservice.IdentityModule.Web.Application.Services;
using Calabonga.OperationResults;
using MediatR;

namespace Calabonga.Microservice.IdentityModule.Web.Application.Messaging.ProfileMessages.Queries;

/// <summary>
/// Register new account
/// </summary>
public sealed class RegisterAccount
{
    public class Request(RegisterViewModel model) : IRequest<OperationResult<UserProfileViewModel>>
    {
        public RegisterViewModel Model { get; } = model;
    }

    public class Handler(IAccountService accountService)
        : IRequestHandler<Request, OperationResult<UserProfileViewModel>>
    {
        public Task<OperationResult<UserProfileViewModel>> Handle(Request request, CancellationToken cancellationToken)
            => accountService.RegisterAsync(request.Model, cancellationToken);
    }
}