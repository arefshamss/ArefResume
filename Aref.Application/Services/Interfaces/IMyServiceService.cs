using Aref.Domain.Shared;
using Aref.Domain.ViewModels.MyService.Admin;
using Aref.Domain.ViewModels.MyService.Client;

namespace Aref.Application.Services.Interfaces;

public interface IMyServiceService
{
    #region Admin

    Task<AdminFilterMyServiceViewModel> FilterAsync(AdminFilterMyServiceViewModel filter);

    Task<Result> CreateAsync(AdminCreateMyServiceViewModel viewModel);

    Task<Result<AdminUpdateMyServiceViewModel>> FillModelForUpdateAsync(short id);

    Task<Result> UpdateAsync(AdminUpdateMyServiceViewModel viewModel);

    Task<Result> DeleteOrRecoverAsync(short id);

    #endregion

    #region Client

    Task<ClientFilterMyServiceViewModel> FilterAsync(ClientFilterMyServiceViewModel filter);

    #endregion
}