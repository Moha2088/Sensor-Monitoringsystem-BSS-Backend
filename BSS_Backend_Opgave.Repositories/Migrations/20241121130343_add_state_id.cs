using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSS_Backend_Opgave.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class add_state_id : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "EventLog",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StateId",
                table: "EventLog");
        }
    }
}
