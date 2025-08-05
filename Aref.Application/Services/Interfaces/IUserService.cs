using Aref.Domain.Shared;
using Aref.Domain.ViewModels.User.Admin;

namespace Aref.Application.Services.Interfaces;

public interface IUserService
{
    #region Admin

    Task<Result<AdminFilterUsersViewModel>> FilterAsync(AdminFilterUsersViewModel filter);
    Task<Result<AdminUserViewModel>> GetByIdAsync(int id);
    Task<Result<AdminUpdateUserViewModel>> FillModelForUpdateAsync(int id);

    Task<Result> CreateAsync(AdminCreateUserViewModel viewModel);
    Task<Result> UpdateAsync(AdminUpdateUserViewModel viewModel);
    Task<Result> DeleteOrRecoverAsync(int id);

    #endregion
    
    #region Account

    Task<Result<AuthenticateUserViewModel>> ConfirmLoginAsync(LoginViewModel viewModel);

    #endregion
}