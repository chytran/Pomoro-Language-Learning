using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pomoro_Language_Learning.Migrations.ApplicationDb
{
    public partial class ReviewToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReviewCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NonTranslated = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Translated = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewCards", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReviewCards");
        }
    }
}
