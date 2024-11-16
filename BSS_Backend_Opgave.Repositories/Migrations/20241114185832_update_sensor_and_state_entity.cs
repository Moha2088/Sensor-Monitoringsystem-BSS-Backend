using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSS_Backend_Opgave.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class update_sensor_and_state_entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SensorId",
                table: "State",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_State_SensorId",
                table: "State",
                column: "SensorId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_State_Sensor_SensorId",
                table: "State",
                column: "SensorId",
                principalTable: "Sensor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_State_Sensor_SensorId",
                table: "State");

            migrationBuilder.DropIndex(
                name: "IX_State_SensorId",
                table: "State");

            migrationBuilder.DropColumn(
                name: "SensorId",
                table: "State");
        }
    }
}
