using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCoreTestApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    ItemNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemNo1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items", x => x.ItemNo);
                    table.ForeignKey(
                        name: "FK_items_items_ItemNo1",
                        column: x => x.ItemNo1,
                        principalTable: "items",
                        principalColumn: "ItemNo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_items_ItemNo1",
                table: "items",
                column: "ItemNo1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "items");
        }
    }
}
