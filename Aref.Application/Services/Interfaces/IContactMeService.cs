using Aref.Domain.Shared;
using Aref.Domain.ViewModels.ContactMe.Admin;
using Aref.Domain.ViewModels.ContactMe.Client;

namespace Aref.Application.Services.Interfaces;

public interface IContactMeService
{
    Task<AdminFilterContactMeViewModel> FilterAsync(AdminFilterContactMeViewModel filter);

    Task<Result<AdminContactMeDetailsViewModel>> GetByIdAsync(short id);

    Task<Result> CreateAsync(ClientCreateContactMeViewModel viewModel);

    Task<Result> DeleteOrRecoverAsync(short id);
}