using Aref.Web.Extensions;
using Serilog;

try
{
    var builder = WebApplication.CreateBuilder(args);

    var app = builder.ConfigServices();
    app.ConfigPipelines();            

    app.Run();
}
catch (Exception exception)
{
    Log.Fatal(exception, "Application terminated unexpectedly.");
    throw;
}
finally
{
    Log.CloseAndFlush();
}