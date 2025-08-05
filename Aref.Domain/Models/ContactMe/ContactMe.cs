using Aref.Domain.Models.Common;

namespace Aref.Domain.Models.ContactMe;

public class ContactMe:BaseEntity<short>
{
    #region Properties

    public required string FullName { get; set; }
    
    public string? Subject { get; set; }

    public string? Email { get; set; }

    public required string Mobile { get; set; }

    public required string Message { get; set; }

    #endregion
}