using Microsoft.EntityFrameworkCore.Migrations;

namespace HogwartsRegistration.Data.Migrations
{
    public partial class isUniqueConstrain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "inscription_request",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HogwartsId = table.Column<long>(type: "INTEGER", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Houses = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inscription_request", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_inscription_request_HogwartsId",
                table: "inscription_request",
                column: "HogwartsId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "inscription_request");
        }
    }
}
