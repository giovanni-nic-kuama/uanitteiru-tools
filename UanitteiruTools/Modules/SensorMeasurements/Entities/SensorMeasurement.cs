using Microsoft.EntityFrameworkCore;
using UanitteiruTools.Common.Entities;

namespace UanitteiruTools.Modules.SensorMeasurements.Entities;

public class SensorMeasurement : BaseEntity
{
    [Precision(5, 2)]
    public decimal Temperature { get; set; }
    [Precision(5, 2)]
    public decimal Humidity { get; set; }
    [Precision(5, 2)]
    public decimal HeatIndex { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}