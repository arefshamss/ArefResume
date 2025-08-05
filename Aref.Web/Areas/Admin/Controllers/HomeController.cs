using Aref.Infra.Data.Statics;
using Aref.Web.Areas.Admin.Controllers.Common;
using Aref.Web.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Aref.Web.Areas.Admin.Controllers;

[InvokePermission(PermissionsName.AdminDashboard)]
public class HomeController : AdminBaseController
{
    public IActionResult Index()
    {
        return View();
    }
}