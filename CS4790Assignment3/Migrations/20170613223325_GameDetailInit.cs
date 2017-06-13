using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CS4790Assignment3.Migrations
{
    public partial class GameDetailInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GameName",
                table: "Review",
                newName: "ReviewedGameName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Publisher",
                newName: "PublisherName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Game",
                newName: "GameName");

            migrationBuilder.AlterColumn<double>(
                name: "HoursPlayed",
                table: "Game",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReviewedGameName",
                table: "Review",
                newName: "GameName");

            migrationBuilder.RenameColumn(
                name: "PublisherName",
                table: "Publisher",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "GameName",
                table: "Game",
                newName: "Name");

            migrationBuilder.AlterColumn<double>(
                name: "HoursPlayed",
                table: "Game",
                nullable: true,
                oldClrType: typeof(double));
        }
    }
}
