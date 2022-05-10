using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleList.Infraestructure.Migrations
{
    public partial class LastModifiedUserIdremoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastModifiedUserId",
                table: "Lists");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedUserId",
                table: "Lists",
                type: "datetime2",
                nullable: true);
        }
    }
}
