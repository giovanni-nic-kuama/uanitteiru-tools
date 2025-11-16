using FluentValidation;
using UanitteiruTools.Common.AppDbContext;
using UanitteiruTools.Common.Environment;
using UanitteiruTools.Modules.ApiLogs.Mappings;
using UanitteiruTools.Modules.SensorMeasurements.Dto;
using UanitteiruTools.Modules.SensorMeasurements.Mappings;

namespace UanitteiruTools.Modules.SensorMeasurements.Services;

public class SensorMeasurementService(
    AppDbContext appDbContext,
    IValidator<SensorMeasurementCreateDto> sensorMeasurementCreateDtoValidator,
    EnvironmentModel environment) : ISensorMeasurementService
{
    public async Task Create(SensorMeasurementCreateDto dto, string? clientSecret)
    {

        if (environment.DeviceSecretKey != clientSecret)
        {
            await CreateUnauthorizedApiLog(clientSecret);
            
            throw new BadHttpRequestException("Unauthorized", 401);
        }
        
        try
        {
            await sensorMeasurementCreateDtoValidator.ValidateAndThrowAsync(dto);
        }
        catch (Exception e)
        {
            await CreateErrorApiLog(e.Message);
            
            throw new BadHttpRequestException(e.Message);
        }
        
        var entity = SensorMeasurementMappings.Map(dto);

        appDbContext.SensorMeasurements.Add(entity);
        await appDbContext.SaveChangesAsync();
    }

    private async Task CreateErrorApiLog(string error)
    {
        var apiLog = ApiLogMappings.MapBadRequest(error);
        appDbContext.ApiLogs.Add(apiLog);
        await appDbContext.SaveChangesAsync();
    }
    
    private async Task CreateUnauthorizedApiLog(string? secret)
    {
        var apiLog = ApiLogMappings.MapUnauthorized(secret);
        appDbContext.ApiLogs.Add(apiLog);
        await appDbContext.SaveChangesAsync();
    }
}