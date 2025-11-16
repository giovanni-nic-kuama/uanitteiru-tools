using UanitteiruTools.Modules.ApiLogs.Entities;

namespace UanitteiruTools.Modules.ApiLogs.Mappings;

public static class ApiLogMappings
{
    public static ApiLog MapBadRequest(string error)
    {
        return new ApiLog
        {
            Code = "BAD_REQUEST",
            Error = error.Length > 200 ? error[..200] : error,
            CreatedAt = DateTime.UtcNow,
        };
    }
    
    public static ApiLog MapUnauthorized(string? key)
    {
        return new ApiLog
        {
            Code = "UNAUTHORIZED",
            Error = $"Received unknown API key: {key}",
            CreatedAt = DateTime.UtcNow,
        };
    }
}