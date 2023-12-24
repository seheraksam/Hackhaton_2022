using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hackathon.DAL.Migrations
{
    public partial class mig6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SessionRecords_SessionId",
                table: "SessionRecords");

            migrationBuilder.CreateIndex(
                name: "IX_SessionRecords_SessionId",
                table: "SessionRecords",
                column: "SessionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SessionRecords_SessionId",
                table: "SessionRecords");

            migrationBuilder.CreateIndex(
                name: "IX_SessionRecords_SessionId",
                table: "SessionRecords",
                column: "SessionId",
                unique: true);
        }
    }
}
