using Aref.Application.Extensions;
using Aref.Application.Statics;
using Aref.Domain.Models.User;
using Aref.Domain.Extensions;
using Aref.Domain.ViewModels.User.Admin;

namespace Aref.Application.Mappers.UserMappings;

public static class UserMapper
{
    #region Admin

    public static AdminUserViewModel MapToAdminUserViewModel(this User model) =>
        new()
        {
            Id = model.Id,
            Mobile = model.Mobile,
            FirstName = model.FirstName,
            LastName = model.LastName,
            AvatarImageName = model.AvatarImageName.IsNullOrEmptyOrWhiteSpace() ? FilePaths.CommonImagesPath + SiteTools.DefaultUserImageName : FilePaths.UserThumbAvatar + model.AvatarImageName,
            CreatedDate = model.CreatedDate,
            IsDeleted = model.IsDeleted,
            Email = model.Email
        };

    public static User MapToUser(this AdminCreateUserViewModel viewModel) =>
        new()
        {
            Mobile = viewModel.Mobile,
            FirstName = viewModel.FirstName,
            LastName = viewModel.LastName,
            Password = viewModel.Password?.HashPassword(),
            Email = viewModel.Email,
            Birthday = viewModel.Birthday,
            Mobile2 = viewModel.Mobile2,
            Notes = viewModel.Notes,
            Address = viewModel.Address,
        };

    public static void MapToUser(this User model, AdminUpdateUserViewModel viewModel)
    {
        model.FirstName = viewModel.FirstName;
        model.LastName = viewModel.LastName;
        model.Mobile = viewModel.Mobile;
        model.Email = viewModel.Email;
        model.Birthday = viewModel.Birthday;
        model.Mobile2 = viewModel.Mobile2;
        model.Notes = viewModel.Notes;
        model.Address = viewModel.Address;
    }

    public static AdminUpdateUserViewModel MapToAdminUpdateUserViewModel(this User model) =>
        new()
        {
            Id = model.Id,
            Mobile = model.Mobile,
            FirstName = model.FirstName,
            LastName = model.LastName,
            AvatarImageName = model.AvatarImageName.IsNullOrEmptyOrWhiteSpace() ? FilePaths.CommonImagesPath + SiteTools.DefaultUserImageName : FilePaths.UserOriginalAvatar + model.AvatarImageName,
            Email = model.Email,
            Birthday = model.Birthday,
            Mobile2 = model.Mobile2,
            Notes = model.Notes,
            Address = model.Address,
        };

    #endregion
    
    #region Account
    
    
    public static AuthenticateUserViewModel MapToAuthenticateUserViewModel(this User model) => 
        new()
        {
            Mobile = model.Mobile,
            FullName = model.GetUserDisplayName(),
            UserId = model.Id,
        };
    
    #endregion
}