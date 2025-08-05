using Aref.Domain.Shared;
using Aref.Domain.ViewModels.CounterBox.Admin;
using Aref.Domain.ViewModels.CounterBox.Client;

namespace Aref.Application.Services.Interfaces;

public interface ICounterBoxService
{
    #region Admin

    Task<AdminFilterCounterBoxViewModel> FilterAsync(AdminFilterCounterBoxViewModel filter);

    Task<Result> CreateAsync(AdminCreateCounterBoxViewModel viewModel);

    Task<Result<AdminUpdateCounterBoxViewModel>> FillModelForUpdateAsync(short id);

    Task<Result> UpdateAsync(AdminUpdateCounterBoxViewModel viewModel);

    Task<Result> DeleteOrRecoverAsync(short id);

    #endregion

    #region Client

    Task<ClientFilterCounterBoxViewModel> FilterAsync(ClientFilterCounterBoxViewModel filter);

    #endregion
}