using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsuranceAPI.Migrations
{
    public partial class CreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InsuranceDetails",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Coverage = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    ValidityTime = table.Column<string>(type: "nvarchar(8)", nullable: false),
                    CoverageTime = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Risk = table.Column<string>(type: "nvarchar(15)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceDetails", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InsuranceDetails");
        }
    }
}
