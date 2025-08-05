using Aref.Domain.Shared;
using Aref.Domain.ViewModels.PageContent.Admin;

namespace Aref.Application.Services.Interfaces;

public interface IPageContentService
{
    #region Admin
    
    Task<Result<AdminUpdatePageContentViewModel>> FillModelForUpdateAsync(short id);

    Task<Result> UpdateAsync(AdminUpdatePageContentViewModel viewModel);

    #endregion
}