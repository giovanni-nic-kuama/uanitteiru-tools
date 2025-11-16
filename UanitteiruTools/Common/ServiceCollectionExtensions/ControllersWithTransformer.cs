using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace UanitteiruTools.Common.ServiceCollectionExtensions;

public static class ControllersWithTransformer
{
    public static void AddControllersWithTransformer(this IServiceCollection services)
    {
        services.AddControllers(options =>
        {
            options.Conventions.Add(new RouteTokenTransformerConvention(new Utils.PascalCaseToKebabCaseRoutesTransformer()));
        });
    }
}