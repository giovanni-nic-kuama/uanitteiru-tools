using FluentValidation;
using UanitteiruTools.Common.Environment;
using UanitteiruTools.Modules.SensorMeasurements.Dto;
using UanitteiruTools.Modules.SensorMeasurements.Services;
using UanitteiruTools.Modules.SensorMeasurements.Validators;

namespace UanitteiruTools.Common.ServiceCollectionExtensions;

public static class ServiceCollectionExtensions
{
    public static void AddUanitteiruToolsServices(this IServiceCollection services, EnvironmentModel environment)
    {
        #region Services

        services.AddScoped<ISensorMeasurementService, SensorMeasurementService>();

        #endregion

        #region Validators

        services.AddSingleton<IValidator<SensorMeasurementCreateDto>, SensorMeasurementCreateDtoValidator>();

        #endregion
    }
}