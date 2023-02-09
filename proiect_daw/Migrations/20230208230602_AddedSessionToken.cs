using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace proiect_daw.Migrations
{
    public partial class AddedSessionToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DebutYear",
                table: "Directors");

            migrationBuilder.CreateTable(
                name: "SessionTokens",
                columns: table => new
                {
                    Jti = table.Column<string>(nullable: false),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionTokens", x => x.Jti);
                    table.ForeignKey(
                        name: "FK_SessionTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SessionTokens_UserId",
                table: "SessionTokens",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SessionTokens");

            migrationBuilder.AddColumn<int>(
                name: "DebutYear",
                table: "Directors",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
