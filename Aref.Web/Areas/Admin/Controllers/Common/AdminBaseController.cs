using Aref.Web.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Aref.Web.Areas.Admin.Controllers.Common;

[Area("Admin")]
[Authorize]
public class AdminBaseController : BaseController;