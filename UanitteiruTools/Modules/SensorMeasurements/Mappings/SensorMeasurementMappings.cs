using UanitteiruTools.Modules.SensorMeasurements.Dto;
using UanitteiruTools.Modules.SensorMeasurements.Entities;

namespace UanitteiruTools.Modules.SensorMeasurements.Mappings;

public static class SensorMeasurementMappings
{
    public static SensorMeasurement Map(SensorMeasurementCreateDto dto)
    {
        return new SensorMeasurement
        {
            Temperature = dto.Temperature!.Value,
            Humidity = dto.Humidity!.Value,
            HeathIndex = dto.HeathIndex!.Value,
            CreatedAt = DateTime.UtcNow
        };
    }
}