using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mov.Mutual.Migrations
{
    public partial class rrr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Privileges",
                columns: table => new
                {
                    PRIVILEGEID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Privileges", x => x.PRIVILEGEID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    USERID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PRIVILEGE = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.USERID);
                    table.ForeignKey(
                        name: "FK_Users_Privileges_PRIVILEGE",
                        column: x => x.PRIVILEGE,
                        principalTable: "Privileges",
                        principalColumn: "PRIVILEGEID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    DIRECTORID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DIRECTOR_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CREATE_DT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATE_DT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CREATE_USER = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.DIRECTORID);
                    table.ForeignKey(
                        name: "FK_Directors_Users_CREATE_USER",
                        column: x => x.CREATE_USER,
                        principalTable: "Users",
                        principalColumn: "USERID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MOVIEID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MOVIE_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DIRECTOR = table.Column<int>(type: "int", nullable: false),
                    IMDB = table.Column<float>(type: "real", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    CREATE_DT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATE_DT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RELEASE_DT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Promo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUser = table.Column<int>(type: "int", nullable: false),
                    UserComment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MOVIEID);
                    table.ForeignKey(
                        name: "FK_Movies_Directors_DIRECTOR",
                        column: x => x.DIRECTOR,
                        principalTable: "Directors",
                        principalColumn: "DIRECTORID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movies_Users_CreateUser",
                        column: x => x.CreateUser,
                        principalTable: "Users",
                        principalColumn: "USERID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Directors_CREATE_USER",
                table: "Directors",
                column: "CREATE_USER");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CreateUser",
                table: "Movies",
                column: "CreateUser");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_DIRECTOR",
                table: "Movies",
                column: "DIRECTOR");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PRIVILEGE",
                table: "Users",
                column: "PRIVILEGE");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Privileges");
        }
    }
}
