using Aref.Domain.Models.PageContent;
using Aref.Domain.ViewModels.PageContent.Admin;

namespace Aref.Application.Mappers.PageContentMappings;

public static class PageContentMapper
{
    #region Admin
    
    public static AdminUpdatePageContentViewModel MapToAdminUpdatePageContentViewModel(this PageContent model) => new()
    {
        Id = model.Id,
        Title = model.Title,
        Description = model.Description,
        PageContentType = model.PageContentType
    };

    public static void MapToPageContent(this AdminUpdatePageContentViewModel viewModel, PageContent model)
    {
        model.Title = viewModel.Title;
        model.Description = viewModel.Description;
        model.PageContentType = viewModel.PageContentType;
    }

    #endregion
}