namespace UanitteiruTools.Common.Environment;

public class EnvironmentModel
{
    public required List<string> AllowedOrigins { get; init; }
    public required string CorsPolicyName { get; init; }
    public required string DatabaseConnectionString { get; init; }
    
    public required string DeviceSecretKey { get; init; }
}