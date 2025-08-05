using Aref.Domain.Shared;
using Aref.Domain.ViewModels.MyProject.Admin;
using Aref.Domain.ViewModels.MyProject.Client;

namespace Aref.Application.Services.Interfaces;

public interface IMyProjectService
{
    #region Admin

    Task<AdminFilterMyProjectViewModel> FilterAsync(AdminFilterMyProjectViewModel filter);

    Task<Result> CreateAsync(AdminCreateMyProjectViewModel viewModel);

    Task<Result<AdminUpdateMyProjectViewModel>> FillModelForUpdateAsync(short id);

    Task<Result> UpdateAsync(AdminUpdateMyProjectViewModel viewModel);

    Task<Result> DeleteOrRecoverAsync(short id);

    #endregion

    #region Client

    Task<ClientFilterMyProjectViewModel> FilterAsync(ClientFilterMyProjectViewModel filter);

    #endregion
}