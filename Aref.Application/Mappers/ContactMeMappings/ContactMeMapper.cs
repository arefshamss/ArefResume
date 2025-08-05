using Aref.Application.Extensions;
using Aref.Domain.Models.ContactMe;
using Aref.Domain.ViewModels.ContactMe.Admin;
using Aref.Domain.ViewModels.ContactMe.Client;

namespace Aref.Application.Mappers.ContactMeMappings;


public static class ContactMeMapper
{
    public static AdminContactMeViewModel MapToContactMeViewModel(this ContactMe model) =>
        new()
        {
            Mobile = model.Mobile,
            FullName = model.FullName,
            Id = model.Id,
            IsDeleted = model.IsDeleted,
            CreatedDate = model.CreatedDate,
        };

    public static AdminContactMeDetailsViewModel MapToAdminContactMeDetailsViewModel(this ContactMe model) =>
        new()
        {
            Mobile = model.Mobile,
            Email = model.Email,
            FullName = model.FullName,
            Subject = model.Subject,
            Id = model.Id,
            CreatedDate = model.CreatedDate,
            Message = model.Message,
        };

    public static ContactMe MapToContactMe(this ClientCreateContactMeViewModel viewModel) =>
        new()
        {
            Email = viewModel.Email,
            Mobile = viewModel.Mobile,
            FullName = viewModel.FullName,
            Subject = viewModel.Subject,
            Message = viewModel.Message,
        };
}