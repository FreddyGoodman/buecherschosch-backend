using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace buecherschosch_service.Migrations
{
    /// <inheritdoc />
    public partial class RenameItemIdColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "Books",
                newName: "Sku");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sku",
                table: "Books",
                newName: "ItemId");
        }
    }
}
