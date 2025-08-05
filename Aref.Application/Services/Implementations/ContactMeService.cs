using Aref.Application.DTOs;
using Aref.Application.Mappers.ContactMeMappings;
using Aref.Application.Services.Interfaces;
using Aref.Domain.Contracts;
using Aref.Domain.Enums.Common;
using Aref.Domain.Models.ContactMe;
using Aref.Domain.Shared;
using Aref.Domain.ViewModels.ContactMe.Admin;
using Aref.Domain.ViewModels.ContactMe.Client;
using Microsoft.EntityFrameworkCore;

namespace Aref.Application.Services.Implementations;

public class ContactMeService(
    IContactMeRepository contactMeRepository,
    IViewRenderService viewRenderService) : IContactMeService
{
    #region FilterAsync

    public async Task<AdminFilterContactMeViewModel> FilterAsync(AdminFilterContactMeViewModel filter)
    {
        var condition = Filter.GenerateConditions<ContactMe>();
        var order = Filter.GenerateOrders<ContactMe>();

        #region Filter

        if (!string.IsNullOrEmpty(filter.Subject))
            condition.Add(u => EF.Functions.Like(u.Subject, $"%{filter.Subject}%"));

        switch (filter.FilterOrderBy)
        {
            case FilterOrderBy.Ascending:
                order.Add(u => u.CreatedDate);
                break;
            case FilterOrderBy.Descending:

                break;
        }

        switch (filter.DeleteStatus)
        {
            case DeleteStatus.All:
                break;
            case DeleteStatus.Deleted:
                condition.Add(u => u.IsDeleted);
                break;
            case DeleteStatus.NotDeleted:
                condition.Add(u => !u.IsDeleted);
                break;
        }

        #endregion

        await contactMeRepository.FilterAsync(filter, condition, u => u.MapToContactMeViewModel(), order);

        return filter;
    }

    #endregion

    #region GetByIdAsync

    public async Task<Result<AdminContactMeDetailsViewModel>> GetByIdAsync(short id)
    {
        if (id < 1)
            return Result.Failure<AdminContactMeDetailsViewModel>(ErrorMessages.BadRequestError);

        var contact = await contactMeRepository.GetByIdAsync(id);

        if (contact is null)
            return Result.Failure<AdminContactMeDetailsViewModel>(ErrorMessages.NotFoundError);

        return contact.MapToAdminContactMeDetailsViewModel();
    }

    #endregion
    
    #region CreateAsync

    public async Task<Result> CreateAsync(ClientCreateContactMeViewModel viewModel)
    {
        var message = viewModel.MapToContactMe();

        await contactMeRepository.InsertAsync(message);

        await contactMeRepository.SaveChangesAsync();
        return Result.Success(SuccessMessages.MessageSentSuccessfully);
    }

    #endregion

    #region DeleteOrRecoverAsync

    public async Task<Result> DeleteOrRecoverAsync(short id)
    {
        if (id < 1)
            return Result.Failure(ErrorMessages.BadRequestError);

        var message = await contactMeRepository.GetByIdAsync(id);

        if (message is null)
            return Result.Failure(ErrorMessages.NotFoundError);

        var result = contactMeRepository.SoftDeleteOrRecover(message);
        await contactMeRepository.SaveChangesAsync();
        if (result)
            return Result.Success(SuccessMessages.DeleteSuccess);

        return Result.Success(SuccessMessages.RecoverSuccess);
    }

    #endregion
}