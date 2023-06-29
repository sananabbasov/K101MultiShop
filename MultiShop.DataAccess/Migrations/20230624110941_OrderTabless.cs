using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiShop.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class OrderTabless : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Product",
                table: "Orders",
                newName: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Orders",
                newName: "Product");
        }
    }
}
