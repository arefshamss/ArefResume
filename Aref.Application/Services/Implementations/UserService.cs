using Aref.Application.Extensions;
using Aref.Application.Services.Interfaces;
using Aref.Application.Statics;
using Aref.Domain.Contracts;
using Aref.Domain.Enums.Common;
using Aref.Domain.Models.User;
using Aref.Domain.Shared;
using Aref.Application.Mappers.UserMappings;
using Aref.Domain.ViewModels.User.Admin;
using Microsoft.EntityFrameworkCore;

namespace Aref.Application.Services.Implementations;

public class UserService(
    IUserRepository userRepository) : IUserService
{
    #region Admin

    public async Task<Result<AdminFilterUsersViewModel>> FilterAsync(AdminFilterUsersViewModel filter)
    {
        filter ??= new();

        var conditions = Filter.GenerateConditions<User>();
        var orders = Filter.GenerateOrders<User>();

        #region Filter

        switch (filter.DeleteStatus)
        {
            case DeleteStatus.Deleted:
                conditions.Add(x => x.IsDeleted);
                break;

            case DeleteStatus.NotDeleted:
                conditions.Add(x => !x.IsDeleted);
                break;
        }

        #endregion

        await userRepository.FilterAsync(filter, conditions, x => x.MapToAdminUserViewModel(), orders);
        return filter;
    }

    public async Task<Result<AdminUserViewModel>> GetByIdAsync(int id)
    {
        if (id < 1)
            return Result.Failure<AdminUserViewModel>(ErrorMessages.BadRequestError);

        var user = await userRepository.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);

        if (user is null)
            return Result.Failure<AdminUserViewModel>(ErrorMessages.NotFoundError);

        return user.MapToAdminUserViewModel();
    }

    public async Task<Result<AdminUpdateUserViewModel>> FillModelForUpdateAsync(int id)
    {
        if (id < 1)
            return Result.Failure<AdminUpdateUserViewModel>(ErrorMessages.BadRequestError);

        var user = await userRepository.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);

        if (user is null)
            return Result.Failure<AdminUpdateUserViewModel>(ErrorMessages.NotFoundError);

        return user.MapToAdminUpdateUserViewModel();
    }


    public async Task<Result> CreateAsync(AdminCreateUserViewModel viewModel)
    {
        #region Validations

        if (!viewModel.Mobile.IsNullOrEmptyOrWhiteSpace() && await userRepository.AnyAsync(x => x.Mobile == viewModel.Mobile && !x.IsDeleted))
            return Result.Failure(string.Format(ErrorMessages.ConflictError, "Mobile Number"));

        #endregion

        var user = viewModel.MapToUser();

        #region Add User Avatar

        if (viewModel.AvatarImageFile is not null)
        {
            var result = await viewModel.AvatarImageFile.AddImageToServer(FilePaths.UserOriginalAvatar, 300, 300,
                FilePaths.UserThumbAvatar);

            if (result.IsFailure)
                return Result.Failure(result.Message!);

            user.AvatarImageName = result.Value;
        }

        #endregion

        await userRepository.InsertAsync(user);
        await userRepository.SaveChangesAsync();

        return Result.Success(SuccessMessages.InsertSuccessfullyDone);
    }

    public async Task<Result> UpdateAsync(AdminUpdateUserViewModel viewModel)
    {
        #region Validations

        if (viewModel.Id < 1)
            return Result.Failure(ErrorMessages.BadRequestError);

        if (await userRepository.AnyAsync(x => x.Mobile == viewModel.Mobile && x.Id != viewModel.Id && !x.IsDeleted))
            return Result.Failure(string.Format(ErrorMessages.ConflictActiveUserError, "Edit"));

        #endregion

        var user = await userRepository.FirstOrDefaultAsync(x => x.Id == viewModel.Id && !x.IsDeleted);

        if (user is null)
            return Result.Failure(ErrorMessages.NotFoundError);

        user.MapToUser(viewModel);
        if (!viewModel.Password.IsNullOrEmptyOrWhiteSpace())
            user.Password = viewModel.Password!.HashPassword();

        #region Add User Avatar

        if (viewModel.AvatarImageFile is not null)
        {
            var result = await viewModel.AvatarImageFile.AddImageToServer(FilePaths.UserOriginalAvatar, 300, 300,
                FilePaths.UserThumbAvatar, deleteFileName: user.AvatarImageName);

            if (result.IsFailure)
                return Result.Failure(result.Message!);

            user.AvatarImageName = result.Value;
        }

        #endregion

        userRepository.Update(user);
        await userRepository.SaveChangesAsync();

        return Result.Success(SuccessMessages.UpdateSuccessfullyDone);
    }

    public async Task<Result> DeleteOrRecoverAsync(int id)
    {
        if (id < 1)
            return Result.Failure(ErrorMessages.BadRequestError);

        var user = await userRepository.GetByIdAsync(id);

        if (user is null)
            return Result.Failure(ErrorMessages.NotFoundError);

        if (!user.Mobile.IsNullOrEmptyOrWhiteSpace() && await userRepository.AnyAsync(x => x.Mobile == user.Mobile && x.Id != user.Id && !x.IsDeleted))
            return Result.Failure(string.Format(ErrorMessages.ConflictActiveUserError, "Recover"));


        var result = userRepository.SoftDeleteOrRecover(user);
        await userRepository.SaveChangesAsync();


        return Result.Success(SuccessMessages.RecoverSuccess);
    }

    #endregion

    #region Account

    public async Task<Result<AuthenticateUserViewModel>> ConfirmLoginAsync(LoginViewModel viewModel)
    {
        if (viewModel.Password.IsNullOrEmptyOrWhiteSpace())
            return Result.Failure<AuthenticateUserViewModel>(string.Format(ErrorMessages.RequiredError, "Password"));

        var user = await userRepository.FirstOrDefaultAsync(x => x.Mobile == viewModel.Mobile.Trim() && !x.IsDeleted);

        if (user is null)
            return Result.Failure<AuthenticateUserViewModel>(ErrorMessages.UserNotFoundError);

        if (!viewModel.Password!.VerifyPassword(user.Password))
            return Result.Failure<AuthenticateUserViewModel>(ErrorMessages.PasswordNotCorrect);

        return Result.Success(user.MapToAuthenticateUserViewModel(), SuccessMessages.LoginSuccessfullyDone);
    }

    #endregion
}