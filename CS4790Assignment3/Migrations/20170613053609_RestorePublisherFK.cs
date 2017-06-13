using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CS4790Assignment3.Migrations
{
    public partial class RestorePublisherFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PublisherID",
                table: "Game",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Game_PublisherID",
                table: "Game",
                column: "PublisherID");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Publisher_PublisherID",
                table: "Game",
                column: "PublisherID",
                principalTable: "Publisher",
                principalColumn: "PublisherID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Publisher_PublisherID",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Game_PublisherID",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "PublisherID",
                table: "Game");
        }
    }
}
