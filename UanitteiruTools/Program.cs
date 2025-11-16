using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using UanitteiruTools.Common.AppDbContext;
using UanitteiruTools.Common.Environment;
using UanitteiruTools.Common.ServiceCollectionExtensions;

var builder = WebApplication.CreateBuilder(args);

var environment = EnvironmentUtils.BuildEnvironment(builder.Configuration);

builder.Services.AddDbContext<AppDbContext>(optionsAction =>
    optionsAction.UseNpgsql(environment.DatabaseConnectionString));

builder.Services.AddControllersWithTransformer();
builder.Services.AddCorsPolicy(environment);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Uanitteiru Tools", Version = "v1" });
});

builder.Services.AddSingleton(environment);
builder.Services.AddUanitteiruToolsServices(environment);

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("v1/swagger.json", "API V1");
    });
}

if (!app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await dbContext.Database.MigrateAsync();
}

app.Run();