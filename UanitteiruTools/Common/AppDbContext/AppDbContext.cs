using Microsoft.EntityFrameworkCore;
using UanitteiruTools.Modules.ApiLogs.Entities;
using UanitteiruTools.Modules.SensorMeasurements.Entities;

namespace UanitteiruTools.Common.AppDbContext;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    #region DbSets

    public virtual DbSet<SensorMeasurement> SensorMeasurements { get; set; }
    public virtual DbSet<ApiLog> ApiLogs { get; set; }

    #endregion


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}