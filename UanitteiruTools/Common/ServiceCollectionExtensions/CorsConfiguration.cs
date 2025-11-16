using UanitteiruTools.Common.Environment;

namespace UanitteiruTools.Common.ServiceCollectionExtensions;

public static class CorsConfiguration
{
    public static void AddCorsPolicy(this IServiceCollection services, EnvironmentModel environment)
    {
        services.AddCors(options => options.AddPolicy(environment.CorsPolicyName, policyBuilder =>
            {
                policyBuilder.WithOrigins(environment.AllowedOrigins.ToArray())
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            }));
    }
}