using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleList.Infraestructure.Migrations
{
    public partial class AddedLastModifiedUserIdwithrighttype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LastModifiedUserId",
                table: "Lists",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastModifiedUserId",
                table: "Lists");
        }
    }
}
