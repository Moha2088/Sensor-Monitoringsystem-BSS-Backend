using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSS_Backend_Opgave.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class s : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SensorId",
                table: "EventLog",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_State_StateType",
                table: "State",
                column: "StateType");

            migrationBuilder.CreateIndex(
                name: "IX_Sensor_Location",
                table: "Sensor",
                column: "Location");

            migrationBuilder.CreateIndex(
                name: "IX_Sensor_Name_Location",
                table: "Sensor",
                columns: new[] { "Name", "Location" });

            migrationBuilder.CreateIndex(
                name: "IX_EventLog_EventTime",
                table: "EventLog",
                column: "EventTime");

            migrationBuilder.CreateIndex(
                name: "IX_EventLog_SensorId",
                table: "EventLog",
                column: "SensorId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventLog_Sensor_SensorId",
                table: "EventLog",
                column: "SensorId",
                principalTable: "Sensor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventLog_Sensor_SensorId",
                table: "EventLog");

            migrationBuilder.DropIndex(
                name: "IX_State_StateType",
                table: "State");

            migrationBuilder.DropIndex(
                name: "IX_Sensor_Location",
                table: "Sensor");

            migrationBuilder.DropIndex(
                name: "IX_Sensor_Name_Location",
                table: "Sensor");

            migrationBuilder.DropIndex(
                name: "IX_EventLog_EventTime",
                table: "EventLog");

            migrationBuilder.DropIndex(
                name: "IX_EventLog_SensorId",
                table: "EventLog");

            migrationBuilder.DropColumn(
                name: "SensorId",
                table: "EventLog");
        }
    }
}
