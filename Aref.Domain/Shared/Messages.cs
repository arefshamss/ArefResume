namespace Aref.Domain.Shared;

public static class SuccessMessages
{
    #region Common

    public const string SuccessfullyDone = "Operation completed successfully!";
    public const string UpdateSuccessfullyDone = "Update completed successfully.";
    public const string InsertSuccessfullyDone = "Addition completed successfully.";
    public const string SavedChangesSuccessfully = "Changes were successfully applied.";
    public const string DeleteSuccess = "Delete operation completed successfully.";
    public const string RecoverSuccess = "Recovery operation completed successfully.";
    public const string ChangeStatusSuccess = "Status changed successfully.";
    public const string ChangePasswordSuccess = "Password changed successfully.";
    public const string MessageSentSuccessfully = "Message was sent successfully.";

    #endregion

    #region User

    public const string LoginSuccessfullyDone = "Logged in successfully.";
    public const string RegisterSuccessfullyDone = "Registration successful. Please enter the code sent to activate your account.";
    public const string OtpSentSuccessfullyDone = "Verification code sent successfully.";
    public const string UserSuccessfullyActivated = "Your account has been successfully activated.";
    public const string LogoutSuccessfullyDone = "You have successfully logged out.";
    public const string UpdateAvatarSuccessfullyDone = "Profile picture updated successfully.";
    public const string DeleteAvatarSuccessfullyDone = "Profile picture deleted successfully.";

    #endregion

    #region Sms

    public const string SmsSentSuccessfully = "SMS was sent successfully.";
    public const string SmsSentToUserSuccessfully = "SMS sent successfully.";

    #endregion
}


public static class ErrorMessages
{
    #region Common

    public const string NotValid = "The entered {0} is not valid.";
    public const string MaxLengthError = "Maximum allowed characters is {1}.";
    public const string MinLengthError = "Minimum required characters is {1}.";
    public const string RequiredError = "{0} is required.";
    public const string NotFoundError = "No item found.";
    public const string RangeError = "The selected range must be between {1} and {2}.";
    public const string OperationFailedError = "Operation failed.";
    public const string BadRequestError = "Your request is invalid.";
    public const string ModelStateNotValid = "Entered data is invalid.";
    public const string SomethingWentWrong = "Something went wrong.";
    public const string AlreadyExistError = "{0} already exists.";
    public const string NullValue = "No data found.";
    public const string CaptchaError = "Validation error! Please try again.";
    public const string AccessDenied = "Access denied.";
    public const string EmailSendError = "An error occurred while sending the email.";

    #endregion

    #region Files

    public const string FileFormatError = "The uploaded file format is invalid.";
    public const string ImageIsRequired = "Uploading an image is required.";
    public const string FileNotFound = "File not found.";

    #endregion

    #region User

    public const string ConflictError = "The entered {0} is already in use.";
    public const string UserNotFoundError = "No user found with the provided information.";
    public const string UserNotActiveError = "Your account is inactive.";
    public const string ExpireConfirmCodeError = "The entered confirmation code has expired.";
    public const string InvalidConfirmationCode = "The entered confirmation code is invalid.";
    public const string PasswordNotCorrect = "The entered password is incorrect.";
    public const string PasswordCompareError = "Password confirmation does not match.";
    public const string UserIsActive = "Your account is already active.";
    public const string RequiredUserFullName = "Please complete your profile information before {0}.";
    public const string ActiveCodeExpireDateTime = "At least 3 minutes must pass before resending the confirmation code.";
    public const string ConflictActiveUserError = "This phone number is already active in the user list, and {0} is not possible.";

    #region UserPosition

    public const string PriorityExist = "This display priority has already been assigned to another user.";
    public const string AlreadyAdded = "A position has already been assigned to this user.";

    #endregion

    #endregion

    #region Sms

    public const string SmsDidNotSendError = "An error occurred while sending the SMS.";

    #endregion
}
