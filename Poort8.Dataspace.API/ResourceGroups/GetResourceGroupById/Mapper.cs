﻿using FastEndpoints;
using Poort8.Dataspace.AuthorizationRegistry.Entities;

namespace Poort8.Dataspace.API.ResourceGroups.GetResourceGroupById;

public class Mapper : ResponseMapper<Response, ResourceGroup>
{
    public override Response FromEntity(ResourceGroup resourceGroup)
    {
        return new Response(
            resourceGroup.ResourceGroupId,
            resourceGroup.UseCase,
            resourceGroup.Name,
            resourceGroup.Description,
            resourceGroup.Provider,
            resourceGroup.Url,
            resourceGroup.Resources.Select(
                f => new Resources.CreateResource.Response(f.ResourceId, f.Name, f.Description, f.UseCase, f.Properties.Select(
                    p => new Resources.CreateResource.ResourcePropertyDto(p.Key, p.Value, p.IsIdentifier)).ToList())).ToList(),
            resourceGroup.Properties.Select(
                p => new ResourceGroupPropertyDto(p.Key, p.Value, p.IsIdentifier)).ToList());
    }
}
