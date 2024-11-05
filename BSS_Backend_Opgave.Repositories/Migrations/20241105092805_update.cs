using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSS_Backend_Opgave.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sensor_Organisation_OrganisationId",
                table: "Sensor");

            migrationBuilder.DropForeignKey(
                name: "FK_Sensor_SensorCategory_SensorCategoryId",
                table: "Sensor");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Organisation_OrganisationId",
                table: "User");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "User",
                type: "varchar(32)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "User",
                type: "varchar(32)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "User",
                type: "varchar(32)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "OrganisationId1",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SensorCategory",
                type: "varchar(32)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Sensor",
                type: "varchar(32)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Sensor",
                type: "varchar(32)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Organisation",
                type: "varchar(32)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "EventLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateType = table.Column<string>(type: "varchar(32)", nullable: false),
                    EventLogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                    table.ForeignKey(
                        name: "FK_State_EventLog_EventLogId",
                        column: x => x.EventLogId,
                        principalTable: "EventLog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_OrganisationId1",
                table: "User",
                column: "OrganisationId1");

            migrationBuilder.CreateIndex(
                name: "IX_State_EventLogId",
                table: "State",
                column: "EventLogId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sensor_Organisation_OrganisationId",
                table: "Sensor",
                column: "OrganisationId",
                principalTable: "Organisation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sensor_SensorCategory_SensorCategoryId",
                table: "Sensor",
                column: "SensorCategoryId",
                principalTable: "SensorCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Organisation_OrganisationId",
                table: "User",
                column: "OrganisationId",
                principalTable: "Organisation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Organisation_OrganisationId1",
                table: "User",
                column: "OrganisationId1",
                principalTable: "Organisation",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sensor_Organisation_OrganisationId",
                table: "Sensor");

            migrationBuilder.DropForeignKey(
                name: "FK_Sensor_SensorCategory_SensorCategoryId",
                table: "Sensor");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Organisation_OrganisationId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Organisation_OrganisationId1",
                table: "User");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "EventLog");

            migrationBuilder.DropIndex(
                name: "IX_User_OrganisationId1",
                table: "User");

            migrationBuilder.DropColumn(
                name: "OrganisationId1",
                table: "User");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(32)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(32)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(32)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SensorCategory",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(32)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Sensor",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(32)");

            migrationBuilder.AlterColumn<int>(
                name: "Location",
                table: "Sensor",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(32)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Organisation",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(32)");

            migrationBuilder.AddForeignKey(
                name: "FK_Sensor_Organisation_OrganisationId",
                table: "Sensor",
                column: "OrganisationId",
                principalTable: "Organisation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sensor_SensorCategory_SensorCategoryId",
                table: "Sensor",
                column: "SensorCategoryId",
                principalTable: "SensorCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Organisation_OrganisationId",
                table: "User",
                column: "OrganisationId",
                principalTable: "Organisation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
