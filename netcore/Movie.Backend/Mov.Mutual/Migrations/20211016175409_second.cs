using Microsoft.EntityFrameworkCore.Migrations;

namespace Mov.Mutual.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Directors_Users_CREATE_USER",
                table: "Directors");

            migrationBuilder.RenameColumn(
                name: "CREATE_USER",
                table: "Directors",
                newName: "CREATEUSER");

            migrationBuilder.RenameIndex(
                name: "IX_Directors_CREATE_USER",
                table: "Directors",
                newName: "IX_Directors_CREATEUSER");

            migrationBuilder.AddForeignKey(
                name: "FK_Directors_Users_CREATEUSER",
                table: "Directors",
                column: "CREATEUSER",
                principalTable: "Users",
                principalColumn: "USERID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Directors_Users_CREATEUSER",
                table: "Directors");

            migrationBuilder.RenameColumn(
                name: "CREATEUSER",
                table: "Directors",
                newName: "CREATE_USER");

            migrationBuilder.RenameIndex(
                name: "IX_Directors_CREATEUSER",
                table: "Directors",
                newName: "IX_Directors_CREATE_USER");

            migrationBuilder.AddForeignKey(
                name: "FK_Directors_Users_CREATE_USER",
                table: "Directors",
                column: "CREATE_USER",
                principalTable: "Users",
                principalColumn: "USERID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
