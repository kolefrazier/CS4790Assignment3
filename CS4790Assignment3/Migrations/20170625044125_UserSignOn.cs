using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CS4790Assignment3.Migrations
{
    public partial class UserSignOn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Review");

            migrationBuilder.CreateTable(
                name: "CartItem",
                columns: table => new
                {
                    ItemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CartID = table.Column<int>(nullable: false),
                    GameID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => x.ItemID);
                    table.ForeignKey(
                        name: "FK_CartItem_Game_GameID",
                        column: x => x.GameID,
                        principalTable: "Game",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Password = table.Column<string>(nullable: false),
                    Role = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_GameID",
                table: "CartItem",
                column: "GameID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItem");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Review",
                nullable: true);
        }
    }
}
