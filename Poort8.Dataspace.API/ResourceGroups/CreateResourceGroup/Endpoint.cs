﻿using FastEndpoints;
using Poort8.Dataspace.AuthorizationRegistry;
using Poort8.Dataspace.AuthorizationRegistry.Exceptions;
using Poort8.Dataspace.Identity;

namespace Poort8.Dataspace.API.ResourceGroups.CreateResourceGroup;

public class Endpoint : Endpoint<Request, Response, Mapper>
{
    public const string Name = "Resource Groups";
    private readonly ILogger<Endpoint> _logger;
    private readonly IAuthorizationRegistry _authorizationRegistry;

    public Endpoint(
        ILoggerFactory loggerFactory,
        IAuthorizationRegistry authorizationRegistry)
    {
        _logger = loggerFactory.CreateLogger<Endpoint>();
        _authorizationRegistry = authorizationRegistry;
    }

    public override void Configure()
    {
        Post($"/api/{Name.ToLower().Replace(" ", "")}");
        Options(x => x.WithTags(Name));
        Description(x =>
        {
            x.ClearDefaultProduces(200);
            x.Produces<Response>(201);
            x.Produces(409);
        });

        AuthSchemes(AuthenticationConstants.IdentityBearer, AuthenticationConstants.Auth0Jwt);
        Policies(AuthenticationConstants.WriteResourcesPolicy);
    }

    public override async Task HandleAsync(Request request, CancellationToken ct)
    {
        var entity = Map.ToEntity(request);

        try
        {
            var resourceGroup = await _authorizationRegistry.CreateResourceGroup(entity);
            await SendMapped(resourceGroup, 201, ct);
        }
        catch (RepositoryException e)
        {
            if (e.Message.StartsWith(RepositoryException.IdNotUnique))
                ThrowError(e.Message, 409);
        }
        catch (Exception e)
        {
            _logger.LogCritical("P8.crit - Error in endpoint {endpointName}: {msg}", Name, e.Message);
            throw;
        }
    }
}
