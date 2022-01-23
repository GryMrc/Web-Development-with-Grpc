using Microsoft.EntityFrameworkCore.Migrations;

namespace Mov.Mutual.Migrations
{
    public partial class addedconstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Privileges_PRIVILEGE",
                table: "Users");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Privileges_PRIVILEGE",
                table: "Users",
                column: "PRIVILEGE",
                principalTable: "Privileges",
                principalColumn: "PRIVILEGEID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Privileges_PRIVILEGE",
                table: "Users");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Privileges_PRIVILEGE",
                table: "Users",
                column: "PRIVILEGE",
                principalTable: "Privileges",
                principalColumn: "PRIVILEGEID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
