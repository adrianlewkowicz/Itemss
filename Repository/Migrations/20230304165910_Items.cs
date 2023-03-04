using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class Items : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GetItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    COD = table.Column<string>(type: "TEXT", maxLength: 12, nullable: true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GetItems", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "GetItems",
                columns: new[] { "Id", "COD", "Title" },
                values: new object[,]
                {
                    { 1, "Testowy", "pierwwszy post" },
                    { 2, "Testowy12", "drugi post" },
                    { 3, "Testowyas", "trzeci post" },
                    { 4, "Testowyassa", "czwarty post" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GetItems");
        }
    }
}
