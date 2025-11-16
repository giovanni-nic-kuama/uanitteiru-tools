using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UanitteiruTools.Migrations
{
    /// <inheritdoc />
    public partial class AlterSensorMeasurementFixTypo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HeathIndex",
                table: "SensorMeasurements",
                newName: "HeatIndex");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HeatIndex",
                table: "SensorMeasurements",
                newName: "HeathIndex");
        }
    }
}
