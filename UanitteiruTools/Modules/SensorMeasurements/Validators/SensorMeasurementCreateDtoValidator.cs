using FluentValidation;
using UanitteiruTools.Modules.SensorMeasurements.Dto;

namespace UanitteiruTools.Modules.SensorMeasurements.Validators;

public class SensorMeasurementCreateDtoValidator : AbstractValidator<SensorMeasurementCreateDto>
{
    public SensorMeasurementCreateDtoValidator()
    {
        RuleFor(e => e.Temperature).NotEmpty();
        RuleFor(e => e.Humidity).NotEmpty();
        RuleFor(e => e.HeatIndex).NotEmpty();
    }
}