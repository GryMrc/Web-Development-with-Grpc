using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mov.Mutual.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    COUNTRYID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.COUNTRYID);
                });

            migrationBuilder.CreateTable(
                name: "Privileges",
                columns: table => new
                {
                    PRIVILEGEID = table.Column<int>(type: "int", nullable: false),
                    ROLE = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Privileges", x => x.PRIVILEGEID);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PERSONID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AGE = table.Column<int>(type: "int", nullable: false),
                    GENDER = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    COUNTRY = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PERSONID);
                    table.ForeignKey(
                        name: "FK_People_Countries_COUNTRY",
                        column: x => x.COUNTRY,
                        principalTable: "Countries",
                        principalColumn: "COUNTRYID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    USERID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USERNAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PASSWORDHASH = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PASSWORDSALT = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
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
                    PERSON = table.Column<int>(type: "int", nullable: false),
                    CREATE_DT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATE_DT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CREATEUSER = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.DIRECTORID);
                    table.ForeignKey(
                        name: "FK_Directors_People_PERSON",
                        column: x => x.PERSON,
                        principalTable: "People",
                        principalColumn: "PERSONID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Directors_Users_CREATEUSER",
                        column: x => x.CREATEUSER,
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
                    MOVIENAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DIRECTOR = table.Column<int>(type: "int", nullable: false),
                    IMDB = table.Column<float>(type: "real", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    CREATE_DT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATE_DT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RELEASE_DT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Promo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CREATEUSER = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_Movies_Users_CREATEUSER",
                        column: x => x.CREATEUSER,
                        principalTable: "Users",
                        principalColumn: "USERID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Directors_CREATEUSER",
                table: "Directors",
                column: "CREATEUSER");

            migrationBuilder.CreateIndex(
                name: "IX_Directors_PERSON",
                table: "Directors",
                column: "PERSON");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CREATEUSER",
                table: "Movies",
                column: "CREATEUSER");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_DIRECTOR",
                table: "Movies",
                column: "DIRECTOR");

            migrationBuilder.CreateIndex(
                name: "IX_People_COUNTRY",
                table: "People",
                column: "COUNTRY");

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
                name: "People");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Privileges");
        }
    }
}
