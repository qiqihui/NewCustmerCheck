using Microsoft.EntityFrameworkCore.Migrations;

namespace NewCustomerCheck.Migrations
{
    public partial class AddActivityModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityModel",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    ActivityApiID = table.Column<string>(nullable: true),
                    ActivityName = table.Column<string>(nullable: true),
                    ActivityKindEnum = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityModel", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityModel");
        }
    }
}
