using Aref.Domain.Shared;
using Aref.Domain.ViewModels.MySkill.Admin;
using Aref.Domain.ViewModels.MySkill.Client;

namespace Aref.Application.Services.Interfaces;

public interface IMySkillService
{
    #region Admin

    Task<AdminFilterMySkillViewModel> FilterAsync(AdminFilterMySkillViewModel filter);

    Task<Result> CreateAsync(AdminCreateMySkillViewModel viewModel);

    Task<Result<AdminUpdateMySkillViewModel>> FillModelForUpdateAsync(short id);

    Task<Result> UpdateAsync(AdminUpdateMySkillViewModel viewModel);

    Task<Result> DeleteOrRecoverAsync(short id);

    #endregion

    #region Client

    Task<ClientFilterMySkillViewModel> FilterAsync(ClientFilterMySkillViewModel filter);

    #endregion
}