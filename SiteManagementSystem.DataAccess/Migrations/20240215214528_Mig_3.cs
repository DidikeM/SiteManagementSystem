using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiteManagementSystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Mig_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SiteManagerId",
                table: "Sites",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsAdmin", "Name", "Password", "Surname", "UserName" },
                values: new object[] { 1, true, "Admin", "admin", "Admin", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Sites_SiteManagerId",
                table: "Sites",
                column: "SiteManagerId",
                unique: true,
                filter: "[SiteManagerId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Sites_Users_SiteManagerId",
                table: "Sites",
                column: "SiteManagerId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sites_Users_SiteManagerId",
                table: "Sites");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Sites_SiteManagerId",
                table: "Sites");

            migrationBuilder.DropColumn(
                name: "SiteManagerId",
                table: "Sites");
        }
    }
}
