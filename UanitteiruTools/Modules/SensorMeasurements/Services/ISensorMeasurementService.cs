using UanitteiruTools.Modules.SensorMeasurements.Dto;

namespace UanitteiruTools.Modules.SensorMeasurements.Services;

public interface ISensorMeasurementService
{
    public Task Create(SensorMeasurementCreateDto dto, string? clientSecret);
}