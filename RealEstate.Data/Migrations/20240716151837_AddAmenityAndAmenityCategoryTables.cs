using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace RealEstate.Data.Migrations
{
    public partial class AddAmenityAndAmenityCategoryTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AmenityCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmenityCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Amenity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<Point>(type: "geography", nullable: false),
                    AmenityCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Amenity_AmenityCategory_AmenityCategoryId",
                        column: x => x.AmenityCategoryId,
                        principalTable: "AmenityCategory",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AmenityCategory",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "School" });

            migrationBuilder.InsertData(
                table: "AmenityCategory",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Metro stations" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c6dae3a-a1c8-48e7-b316-0c2e55999335", "AQAAAAEAACcQAAAAEODte9T/6XMG+pQTKc2s7Hpf2QFLV7vdyKs1FffmpXV2uox9CU4MZoX3kdridY3tpw==", "87c5ab72-439f-4603-a451-38c30abc2e76" });

            migrationBuilder.CreateIndex(
                name: "IX_Amenity_AmenityCategoryId",
                table: "Amenity",
                column: "AmenityCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amenity");

            migrationBuilder.DropTable(
                name: "AmenityCategory");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7863b74c-c19c-497f-a2df-a82e0ef66a42", "AQAAAAEAACcQAAAAEDPbP04C/1LGDER45dHwXETQn7rTcrCtLcU68puvddrqwd+pG5nfGW2RjiYSo5ZnVw==", "65c95722-c9ed-498a-a65a-2806463a9dd1" });
        }
    }
}
