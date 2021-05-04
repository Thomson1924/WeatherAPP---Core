using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherAPP___Core.Data.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "mains",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_mains_UserId",
                table: "mains",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_mains_AspNetUsers_UserId",
                table: "mains",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mains_AspNetUsers_UserId",
                table: "mains");

            migrationBuilder.DropIndex(
                name: "IX_mains_UserId",
                table: "mains");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "mains");
        }
    }
}
