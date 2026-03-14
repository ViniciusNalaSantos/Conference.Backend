using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Conference.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedColumnAttendeeInSeatsAvailabilityTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AttendeeId",
                table: "SeatsAvailability",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SeatsAvailability_AttendeeId",
                table: "SeatsAvailability",
                column: "AttendeeId");

            migrationBuilder.AddForeignKey(
                name: "Fk_SeatsAvailability_Attendees_AttendeeId",
                table: "SeatsAvailability",
                column: "AttendeeId",
                principalTable: "Attendees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Fk_SeatsAvailability_Attendees_AttendeeId",
                table: "SeatsAvailability");

            migrationBuilder.DropIndex(
                name: "IX_SeatsAvailability_AttendeeId",
                table: "SeatsAvailability");

            migrationBuilder.DropColumn(
                name: "AttendeeId",
                table: "SeatsAvailability");
        }
    }
}
