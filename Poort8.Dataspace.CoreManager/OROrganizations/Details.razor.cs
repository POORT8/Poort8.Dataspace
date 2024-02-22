﻿using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;
using Poort8.Dataspace.OrganizationRegistry;
using Poort8.Dataspace.CoreManager.Services;
using Poort8.Dataspace.CoreManager.OROrganizations.Dialogs;

namespace Poort8.Dataspace.CoreManager.OROrganizations;

public partial class Details : IDisposable
{
    private bool disposedValue;
    [Parameter]
    public required string Identifier { get; set; }
    [Inject]
    public required StateContainer StateContainer { get; set; }
    [Inject]
    public required NavigationManager NavigationManager { get; set; }
    [Inject]
    public required IOrganizationRegistry OrganizationRegistry { get; set; }
    [Inject]
    public required IDialogService DialogService { get; set; }

    protected override void OnInitialized()
    {
        StateContainer.OnChange += StateHasChanged;
    }

    private async Task EditOrganizationClicked()
    {
        var parameters = new DialogParameters()
        {
            Title = $"Edit Organization",
            PrimaryAction = "Save Changes",
            PrimaryActionEnabled = true,
            SecondaryAction = "Cancel",
            Width = "400px",
            TrapFocus = true,
            Modal = true,
            ShowDismiss = false,
            OnDialogResult = DialogService.CreateDialogCallback(this, HandleEditOrganizationClicked)
        };

        await DialogService.ShowDialogAsync<OrganizationDialog>(StateContainer.CurrentOROrganization!, parameters);
    }

    private async Task HandleEditOrganizationClicked(DialogResult result)
    {
        if (!result.Cancelled && result.Data is not null)
        {
            StateContainer.CurrentOROrganization = await OrganizationRegistry.UpdateOrganization((Organization)result.Data);
        }
        else
        {
            StateContainer.CurrentOROrganization = await OrganizationRegistry.ReadOrganization(StateContainer.CurrentOROrganization!.Identifier);
        }
    }

    private async Task EditAdditionalDetailsClicked()
    {
        var parameters = new DialogParameters()
        {
            Title = $"Edit additional details",
            PrimaryAction = "Save Changes",
            PrimaryActionEnabled = true,
            SecondaryAction = "Cancel",
            Width = "400px",
            TrapFocus = true,
            Modal = true,
            ShowDismiss = false,
            OnDialogResult = DialogService.CreateDialogCallback(this, HandleEditAdditionalDetailsClicked)
        };

        await DialogService.ShowDialogAsync<OrganizationAdditionalDetailsDialog>(StateContainer.CurrentOROrganization!, parameters);
    }

    private async Task HandleEditAdditionalDetailsClicked(DialogResult result)
    {
        if (!result.Cancelled && result.Data is not null)
        {
            StateContainer.CurrentOROrganization = await OrganizationRegistry.UpdateOrganization((Organization)result.Data);
        }
        else
        {
            StateContainer.CurrentOROrganization = await OrganizationRegistry.ReadOrganization(StateContainer.CurrentOROrganization!.Identifier);
        }
    }

    private void BackClicked()
    {
        NavigationManager!.NavigateTo($"/or/organizations");
    }

    private async Task AddNewAuthorizationRegistryClicked() //TODO: To AuthorizationRegistry component?
    {
        var parameters = new DialogParameters()
        {
            Title = $"New Authorization Registry",
            PrimaryAction = "Add New Authorization Registry",
            PrimaryActionEnabled = true,
            SecondaryAction = "Cancel",
            Width = "400px",
            TrapFocus = true,
            Modal = true,
            ShowDismiss = false,
            OnDialogResult = DialogService.CreateDialogCallback(this, HandleAddNewAuthorizationRegistryClicked)
        };

        var authorizationRegistry = new OrganizationRegistry.AuthorizationRegistry(string.Empty, string.Empty);
        await DialogService.ShowDialogAsync<AuthorizationRegistryDialog>(authorizationRegistry, parameters);
    }

    private async Task HandleAddNewAuthorizationRegistryClicked(DialogResult result)
    {
        if (!result.Cancelled && result.Data is not null)
        {
            await OrganizationRegistry.AddNewAuthorizationRegistryToOrganization(StateContainer.CurrentOROrganization!.Identifier, (OrganizationRegistry.AuthorizationRegistry)result.Data);
            StateContainer.CurrentOROrganization = await OrganizationRegistry.ReadOrganization(StateContainer.CurrentOROrganization!.Identifier);
        }
    }

    private async Task AuthorizationRegistryEditClicked(OrganizationRegistry.AuthorizationRegistry authorizationRegistry)
    {
        var parameters = new DialogParameters()
        {
            Title = $"Edit Authorization Registry",
            PrimaryAction = "Save Changes",
            PrimaryActionEnabled = true,
            SecondaryAction = "Cancel",
            Width = "400px",
            TrapFocus = true,
            Modal = true,
            ShowDismiss = false,
            OnDialogResult = DialogService.CreateDialogCallback(this, HandleEditAuthorizationRegistryClicked)
        };

        await DialogService.ShowDialogAsync<AuthorizationRegistryDialog>(authorizationRegistry, parameters);
    }

    private async Task HandleEditAuthorizationRegistryClicked(DialogResult result)
    {
        if (!result.Cancelled && result.Data is not null)
        {
            await OrganizationRegistry.UpdateAuthorizationRegistry((OrganizationRegistry.AuthorizationRegistry)result.Data);
        }
        StateContainer.CurrentOROrganization = await OrganizationRegistry.ReadOrganization(StateContainer.CurrentOROrganization!.Identifier);
    }

    private async Task AuthorizationRegistryDeleteClicked(OrganizationRegistry.AuthorizationRegistry authorizationRegistry)
    {
        var dialog = await DialogService.ShowConfirmationAsync(
            $"Are you sure you want to delete {authorizationRegistry.AuthorizationRegistryOrganizationId}?",
            "Delete",
            "Cancel",
            "Delete Authorization Registry");

        var result = await dialog.Result;
        if (!result.Cancelled)
        {
            await OrganizationRegistry.DeleteAuthorizationRegistry(authorizationRegistry.AuthorizationRegistryId);
            StateContainer.CurrentOROrganization = await OrganizationRegistry.ReadOrganization(StateContainer.CurrentOROrganization!.Identifier);
        }
    }

    private async Task AddNewCertificateClicked() //TODO: To Certificate component?
    {
        var parameters = new DialogParameters()
        {
            Title = $"New Certificate",
            PrimaryAction = "Add New Certificate",
            PrimaryActionEnabled = true,
            SecondaryAction = "Cancel",
            Width = "400px",
            TrapFocus = true,
            Modal = true,
            ShowDismiss = false,
            OnDialogResult = DialogService.CreateDialogCallback(this, HandleAddNewCertificateClicked)
        };

        var certificate = new Certificate(Array.Empty<byte>(), DateOnly.FromDateTime(DateTime.Now));
        await DialogService.ShowDialogAsync<CertificateDialog>(certificate, parameters);
    }

    private async Task HandleAddNewCertificateClicked(DialogResult result)
    {
        if (!result.Cancelled && result.Data is not null)
        {
            await OrganizationRegistry.AddNewCertificateToOrganization(StateContainer.CurrentOROrganization!.Identifier, (Certificate)result.Data);
            StateContainer.CurrentOROrganization = await OrganizationRegistry.ReadOrganization(StateContainer.CurrentOROrganization!.Identifier);
        }
    }

    private async Task CertificateEditClicked(Certificate certificate)
    {
        var parameters = new DialogParameters()
        {
            Title = $"Edit Certificate",
            PrimaryAction = "Save Changes",
            PrimaryActionEnabled = true,
            SecondaryAction = "Cancel",
            Width = "400px",
            TrapFocus = true,
            Modal = true,
            ShowDismiss = false,
            OnDialogResult = DialogService.CreateDialogCallback(this, HandleEditCertificateClicked)
        };

        await DialogService.ShowDialogAsync<CertificateDialog>(certificate, parameters);
    }

    private async Task HandleEditCertificateClicked(DialogResult result)
    {
        if (!result.Cancelled && result.Data is not null)
        {
            await OrganizationRegistry.UpdateCertificate((Certificate)result.Data);
        }
        StateContainer.CurrentOROrganization = await OrganizationRegistry.ReadOrganization(StateContainer.CurrentOROrganization!.Identifier);
    }

    private async Task CertificateDeleteClicked(Certificate certificate)
    {
        var dialog = await DialogService.ShowConfirmationAsync(
            $"Are you sure you want to delete {certificate.CertificateId}?",
            "Delete",
            "Cancel",
            "Delete Certificate");

        var result = await dialog.Result;
        if (!result.Cancelled)
        {
            await OrganizationRegistry.DeleteCertificate(certificate.CertificateId);
            StateContainer.CurrentOROrganization = await OrganizationRegistry.ReadOrganization(StateContainer.CurrentOROrganization!.Identifier);
        }
    }

    private async Task AddNewRoleClicked() //TODO: To Role component?
    {
        var parameters = new DialogParameters()
        {
            Title = $"New Role",
            PrimaryAction = "Add New Role",
            PrimaryActionEnabled = true,
            SecondaryAction = "Cancel",
            Width = "400px",
            TrapFocus = true,
            Modal = true,
            ShowDismiss = false,
            OnDialogResult = DialogService.CreateDialogCallback(this, HandleAddNewRoleClicked)
        };

        var role = new OrganizationRole(string.Empty);
        await DialogService.ShowDialogAsync<OrganizationRoleDialog>(role, parameters);
    }

    private async Task HandleAddNewRoleClicked(DialogResult result)
    {
        if (!result.Cancelled && result.Data is not null)
        {
            await OrganizationRegistry.AddNewRoleToOrganization(StateContainer.CurrentOROrganization!.Identifier, (OrganizationRole)result.Data);
            StateContainer.CurrentOROrganization = await OrganizationRegistry.ReadOrganization(StateContainer.CurrentOROrganization!.Identifier);
        }
    }

    private async Task RoleEditClicked(OrganizationRole role)
    {
        var parameters = new DialogParameters()
        {
            Title = $"Edit Role",
            PrimaryAction = "Save Changes",
            PrimaryActionEnabled = true,
            SecondaryAction = "Cancel",
            Width = "400px",
            TrapFocus = true,
            Modal = true,
            ShowDismiss = false,
            OnDialogResult = DialogService.CreateDialogCallback(this, HandleEditRoleClicked)
        };

        await DialogService.ShowDialogAsync<OrganizationRoleDialog>(role, parameters);
    }

    private async Task HandleEditRoleClicked(DialogResult result)
    {
        if (!result.Cancelled && result.Data is not null)
        {
            await OrganizationRegistry.UpdateRole((OrganizationRole)result.Data);
        }
        StateContainer.CurrentOROrganization = await OrganizationRegistry.ReadOrganization(StateContainer.CurrentOROrganization!.Identifier);
    }

    private async Task RoleDeleteClicked(OrganizationRole role)
    {
        var dialog = await DialogService.ShowConfirmationAsync(
            $"Are you sure you want to delete {role.Role}?",
            "Delete",
            "Cancel",
            "Delete Role");

        var result = await dialog.Result;
        if (!result.Cancelled)
        {
            await OrganizationRegistry.DeleteRole(role.RoleId);
            StateContainer.CurrentOROrganization = await OrganizationRegistry.ReadOrganization(StateContainer.CurrentOROrganization!.Identifier);
        }
    }

    private async Task AddNewServiceClicked() //TODO: To Service component?
    {
        var parameters = new DialogParameters()
        {
            Title = $"New Service",
            PrimaryAction = "Add New Service",
            PrimaryActionEnabled = true,
            SecondaryAction = "Cancel",
            Width = "400px",
            TrapFocus = true,
            Modal = true,
            ShowDismiss = false,
            OnDialogResult = DialogService.CreateDialogCallback(this, HandleAddNewServiceClicked)
        };

        var service = new Service(string.Empty);
        await DialogService.ShowDialogAsync<ServiceDialog>(service, parameters);
    }

    private async Task HandleAddNewServiceClicked(DialogResult result)
    {
        if (!result.Cancelled && result.Data is not null)
        {
            await OrganizationRegistry.AddNewServiceToOrganization(StateContainer.CurrentOROrganization!.Identifier, (Service)result.Data);
            StateContainer.CurrentOROrganization = await OrganizationRegistry.ReadOrganization(StateContainer.CurrentOROrganization!.Identifier);
        }
    }

    private async Task ServiceEditClicked(Service service)
    {
        var parameters = new DialogParameters()
        {
            Title = $"Edit Service",
            PrimaryAction = "Save Changes",
            PrimaryActionEnabled = true,
            SecondaryAction = "Cancel",
            Width = "400px",
            TrapFocus = true,
            Modal = true,
            ShowDismiss = false,
            OnDialogResult = DialogService.CreateDialogCallback(this, HandleEditServiceClicked)
        };

        await DialogService.ShowDialogAsync<ServiceDialog>(service, parameters);
    }

    private async Task HandleEditServiceClicked(DialogResult result)
    {
        if (!result.Cancelled && result.Data is not null)
        {
            await OrganizationRegistry.UpdateService((Service)result.Data);
        }
        StateContainer.CurrentOROrganization = await OrganizationRegistry.ReadOrganization(StateContainer.CurrentOROrganization!.Identifier);
    }

    private async Task ServiceDeleteClicked(Service service)
    {
        var dialog = await DialogService.ShowConfirmationAsync(
            $"Are you sure you want to delete {service.Name}?",
            "Delete",
            "Cancel",
            "Delete Service");

        var result = await dialog.Result;
        if (!result.Cancelled)
        {
            await OrganizationRegistry.DeleteService(service.ServiceId);
            StateContainer.CurrentOROrganization = await OrganizationRegistry.ReadOrganization(StateContainer.CurrentOROrganization!.Identifier);
        }
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing) StateContainer!.OnChange -= StateHasChanged;
            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}