using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstate.Data.Migrations
{
    public partial class AddPropertyCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Categories_CategoryId",
                table: "Properties");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "PropertyCategoryId",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "SquareMeters",
                table: "Properties",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "PropertyCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SaleCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleCategories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "PropertyCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "House" },
                    { 2, "Apartments" }
                });

            migrationBuilder.InsertData(
                table: "SaleCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Rbnb" },
                    { 2, "Rent" },
                    { 3, "Sale" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Properties_PropertyCategoryId",
                table: "Properties",
                column: "PropertyCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_PropertyCategories_PropertyCategoryId",
                table: "Properties",
                column: "PropertyCategoryId",
                principalTable: "PropertyCategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_SaleCategories_CategoryId",
                table: "Properties",
                column: "CategoryId",
                principalTable: "SaleCategories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_PropertyCategories_PropertyCategoryId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_SaleCategories_CategoryId",
                table: "Properties");

            migrationBuilder.DropTable(
                name: "PropertyCategories");

            migrationBuilder.DropTable(
                name: "SaleCategories");

            migrationBuilder.DropIndex(
                name: "IX_Properties_PropertyCategoryId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "PropertyCategoryId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "SquareMeters",
                table: "Properties");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Categories_CategoryId",
                table: "Properties",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
