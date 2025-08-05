using System.Text;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Aref.Web.Extensions;

internal static class ModelStateExtensions
{
    internal static string GetModelErrorsAsString(this ModelStateDictionary modelState)
    {
        var modelStateErrors = modelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
            .ToList();
        StringBuilder stringBuilder = new();
        stringBuilder.AppendLine("Please fix the following errors:");
        int i = 1;
        modelStateErrors.ForEach(error => { stringBuilder.AppendLine(i++ + ". " + error); });

        return stringBuilder.ToString();
    }
}