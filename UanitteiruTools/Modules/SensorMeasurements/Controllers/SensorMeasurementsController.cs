using Microsoft.AspNetCore.Mvc;
using UanitteiruTools.Modules.SensorMeasurements.Dto;
using UanitteiruTools.Modules.SensorMeasurements.Services;

namespace UanitteiruTools.Modules.SensorMeasurements.Controllers;

[Route("api/[controller]")]
public class SensorMeasurementsController(ISensorMeasurementService sensorMeasurementService) : ControllerBase
{
    [HttpPost]
    public async Task Insert([FromBody] SensorMeasurementCreateDto dto,
        [FromHeader(Name = "X-Client-Secret")] string? clientSecret)
    {
        await sensorMeasurementService.Create(dto, clientSecret);
    }
}