using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCoreTestApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    ItemNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ParentItemNo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items", x => x.ItemNo);
                    table.ForeignKey(
                        name: "FK_items_items_ParentItemNo",
                        column: x => x.ParentItemNo,
                        principalTable: "items",
                        principalColumn: "ItemNo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_items_ParentItemNo",
                table: "items",
                column: "ParentItemNo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "items");
        }
    }
}
