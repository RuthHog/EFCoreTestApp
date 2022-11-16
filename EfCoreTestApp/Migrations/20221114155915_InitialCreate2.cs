using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCoreTestApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_items_items_ParentItemNo",
                table: "items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_items",
                table: "items");

            migrationBuilder.DropIndex(
                name: "IX_items_ParentItemNo",
                table: "items");

            migrationBuilder.AlterColumn<string>(
                name: "ParentItemNo",
                table: "items",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemNo1",
                table: "items",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemParentItemNo",
                table: "items",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_items",
                table: "items",
                columns: new[] { "ItemNo", "ParentItemNo" });

            migrationBuilder.CreateIndex(
                name: "IX_items_ItemNo1_ItemParentItemNo",
                table: "items",
                columns: new[] { "ItemNo1", "ItemParentItemNo" });

            migrationBuilder.AddForeignKey(
                name: "FK_items_items_ItemNo1_ItemParentItemNo",
                table: "items",
                columns: new[] { "ItemNo1", "ItemParentItemNo" },
                principalTable: "items",
                principalColumns: new[] { "ItemNo", "ParentItemNo" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_items_items_ItemNo1_ItemParentItemNo",
                table: "items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_items",
                table: "items");

            migrationBuilder.DropIndex(
                name: "IX_items_ItemNo1_ItemParentItemNo",
                table: "items");

            migrationBuilder.DropColumn(
                name: "ItemNo1",
                table: "items");

            migrationBuilder.DropColumn(
                name: "ItemParentItemNo",
                table: "items");

            migrationBuilder.AlterColumn<string>(
                name: "ParentItemNo",
                table: "items",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_items",
                table: "items",
                column: "ItemNo");

            migrationBuilder.CreateIndex(
                name: "IX_items_ParentItemNo",
                table: "items",
                column: "ParentItemNo");

            migrationBuilder.AddForeignKey(
                name: "FK_items_items_ParentItemNo",
                table: "items",
                column: "ParentItemNo",
                principalTable: "items",
                principalColumn: "ItemNo");
        }
    }
}
