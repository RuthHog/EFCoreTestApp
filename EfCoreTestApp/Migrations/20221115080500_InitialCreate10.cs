using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCoreTestApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentItemNo",
                table: "items");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ParentItemNo",
                table: "items",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
