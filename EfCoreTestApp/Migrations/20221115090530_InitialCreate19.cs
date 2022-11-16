using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCoreTestApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate19 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.CreateTable(
                name: "folder",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_folder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_folder_folder_ParentId",
                        column: x => x.ParentId,
                        principalTable: "folder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_folder_ParentId",
                table: "folder",
                column: "ParentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "folder");

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
    }
}
