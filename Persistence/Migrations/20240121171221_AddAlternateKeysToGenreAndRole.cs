using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddAlternateKeysToGenreAndRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_Roles_Name",
                table: "Roles",
                column: "Name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Genres_Name",
                table: "Genres",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Roles_Name",
                table: "Roles");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Genres_Name",
                table: "Genres");
        }
    }
}
