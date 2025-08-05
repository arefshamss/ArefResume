using Aref.Web.Helpers.FileResults;
using Microsoft.AspNetCore.Mvc;

namespace Aref.Web.Extensions;

public static class JsonFileResultExtensions
{
    public static JsonFileResult<TValue> ToJsonFileResult<TValue>(this Controller controller, TValue value)
    {
        return new JsonFileResult<TValue>(value);
    }
}