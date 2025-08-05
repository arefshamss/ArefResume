using Aref.Domain.Shared;
using Aref.Domain.ViewModels.MyResume.Admin;
using Aref.Domain.ViewModels.MyResume.Client;

namespace Aref.Application.Services.Interfaces;

public interface IMyResumeService
{
    #region Admin

    Task<AdminFilterMyResumeViewModel> FilterAsync(AdminFilterMyResumeViewModel filter);

    Task<Result> CreateAsync(AdminCreateMyResumeViewModel viewModel);

    Task<Result<AdminUpdateMyResumeViewModel>> FillModelForUpdateAsync(short id);

    Task<Result> UpdateAsync(AdminUpdateMyResumeViewModel viewModel);

    Task<Result> DeleteOrRecoverAsync(short id);

    #endregion

    #region Client

    Task<ClientFilterMyResumeViewModel> FilterAsync(ClientFilterMyResumeViewModel filter);

    #endregion
}