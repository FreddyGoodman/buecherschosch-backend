using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace buecherschosch_service.Migrations
{
    /// <inheritdoc />
    public partial class ItemBookExtension : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "Books",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ItemId",
                table: "Books",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Books",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Books");
        }
    }
}
