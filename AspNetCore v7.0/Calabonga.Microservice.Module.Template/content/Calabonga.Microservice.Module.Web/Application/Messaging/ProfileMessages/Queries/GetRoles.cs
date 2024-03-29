﻿using Calabonga.Microservices.Core;
using MediatR;
using System.Security.Claims;

namespace Calabonga.Microservice.Module.Web.Application.Messaging.ProfileMessages.Queries;

/// <summary>
/// Request: Returns user roles 
/// </summary>
public class GetProfile
{
    public record Request : IRequest<string>;

    public class Handler : IRequestHandler<Request, string>
    {
        private readonly ILogger<Handler> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Handler(
            ILogger<Handler> logger,
            IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<string> Handle(Request request, CancellationToken cancellationToken)
        {
            var user = _httpContextAccessor.HttpContext!.User;
            var roles = ClaimsHelper.GetValues<string>((ClaimsIdentity)user.Identity!, ClaimTypes.Role);
            var message = $"Current user ({user.Identity!.Name}) have following roles: {string.Join("|", roles)}";
            _logger.LogInformation(message);
            return Task.FromResult(message);
        }
    }
}
