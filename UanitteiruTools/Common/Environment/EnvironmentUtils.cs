using UanitteiruTools.Common.Exceptions;

namespace UanitteiruTools.Common.Environment;

public static class EnvironmentUtils
{
    private const string AllowedOriginsKey = "AllowedOrigins";
    private const string DatabaseConnectionStringKey = "ConnectionString";
    private const string DeviceSecretKeyKey = "DeviceSecretKey";
    private const string CorsPolicyNameKey = "doof-api-cors-policy";

    public static EnvironmentModel BuildEnvironment(IConfiguration configuration)
    {
        var databaseConnectionString = configuration.GetValue<string>(DatabaseConnectionStringKey);
        var deviceSecretKey = configuration.GetValue<string>(DeviceSecretKeyKey);
        var allowedOrigins = configuration.GetSection(AllowedOriginsKey).Get<List<string>>();

        if (databaseConnectionString is null)
        {
            throw new EnvPropertyNotFoundException($"Key {DatabaseConnectionStringKey} not found on env");
        }
        
        if (deviceSecretKey is null)
        {
            throw new EnvPropertyNotFoundException($"Key {DeviceSecretKeyKey} not found on env");
        }
        
        return new EnvironmentModel
        {
            AllowedOrigins = allowedOrigins ?? [],
            CorsPolicyName = CorsPolicyNameKey,
            DatabaseConnectionString = databaseConnectionString,
            DeviceSecretKey = deviceSecretKey
        };
    }
}