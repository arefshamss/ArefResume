using Aref.Domain.Shared;
using Aref.Domain.ViewModels.MyInfo.Admin;

namespace Aref.Application.Services.Interfaces;


public interface IMyInfoService
{
    #region Admin

    Task<Result<AdminUpdateMyInfoViewModel>> FillModelForUpdateAsync(short id);

    Task<Result> UpdateAsync(AdminUpdateMyInfoViewModel viewModel);

    #endregion
}