using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherAPP___Core.Data.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mains",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Temperature = table.Column<double>(nullable: false),
                    Pressure = table.Column<long>(nullable: false),
                    Humidity = table.Column<long>(nullable: false),
                    TempMin = table.Column<double>(nullable: false),
                    TempMax = table.Column<double>(nullable: false),
                    Percepita = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mains", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mains");
        }
    }
}
