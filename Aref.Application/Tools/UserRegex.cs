using System.Text.RegularExpressions;
using Aref.Domain.Shared;

namespace Aref.Application.Tools;

public partial class UserRegex
{
    [GeneratedRegex(SiteRegex.MobileRegex)]
    public static partial Regex MobileRegex();
    
    [GeneratedRegex(SiteRegex.EmailRegex)]
    public static partial Regex EmailRegex();   
}