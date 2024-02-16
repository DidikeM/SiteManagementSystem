using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiteManagementSystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FlatOwnerId",
                table: "Flats",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "Flats",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonNotes_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flats_FlatOwnerId",
                table: "Flats",
                column: "FlatOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Flats_TenantId",
                table: "Flats",
                column: "TenantId",
                unique: true,
                filter: "[TenantId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PersonNotes_PersonId",
                table: "PersonNotes",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flats_People_FlatOwnerId",
                table: "Flats",
                column: "FlatOwnerId",
                principalTable: "People",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Flats_People_TenantId",
                table: "Flats",
                column: "TenantId",
                principalTable: "People",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flats_People_FlatOwnerId",
                table: "Flats");

            migrationBuilder.DropForeignKey(
                name: "FK_Flats_People_TenantId",
                table: "Flats");

            migrationBuilder.DropTable(
                name: "PersonNotes");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropIndex(
                name: "IX_Flats_FlatOwnerId",
                table: "Flats");

            migrationBuilder.DropIndex(
                name: "IX_Flats_TenantId",
                table: "Flats");

            migrationBuilder.DropColumn(
                name: "FlatOwnerId",
                table: "Flats");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Flats");
        }
    }
}
