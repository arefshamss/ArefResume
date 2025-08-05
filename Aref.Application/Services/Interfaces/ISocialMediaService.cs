using Aref.Domain.Shared;
using Aref.Domain.ViewModels.SocialMedia.Admin;
using Aref.Domain.ViewModels.SocialMedia.Client;

namespace Aref.Application.Services.Interfaces;

public interface ISocialMediaService
{
    #region Admin

    Task<AdminFilterSocialMediaViewModel> FilterAsync(AdminFilterSocialMediaViewModel filter);

    Task<Result> CreateAsync(AdminCreateSocialMediaViewModel viewModel);

    Task<Result<AdminUpdateSocialMediaViewModel>> FillModelForUpdateAsync(short id);

    Task<Result> UpdateAsync(AdminUpdateSocialMediaViewModel viewModel);

    Task<Result> DeleteOrRecoverAsync(short id);

    #endregion

    #region Client

    Task<ClientFilterSocialMediaViewModel> FilterAsync(ClientFilterSocialMediaViewModel filter);

    #endregion
}