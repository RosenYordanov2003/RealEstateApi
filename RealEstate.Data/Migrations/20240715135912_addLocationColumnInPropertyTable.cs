using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace RealEstate.Data.Migrations
{
    public partial class addLocationColumnInPropertyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SaleCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Properties");

            migrationBuilder.AddColumn<Point>(
                name: "Location",
                table: "Properties",
                type: "geography",
                nullable: false,
                defaultValue: (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (0 0)"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5cbe4247-0dc3-4587-a8ad-1c33091f22d6", "AQAAAAEAACcQAAAAENlETdnfAjV96dFQqEFq3Xu/bLc7ic4XUHmcb6CWPJveRbCth+vr79KhtabmGhDMtA==", "31eac542-7609-4c96-87af-4ef534374036" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("a3447384-56ea-485d-98d7-0020ad5dc217"),
                columns: new[] { "Location", "SaleCategoryId" },
                values: new object[] { (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (42.64060043988789 23.323711680764)"), 1 });

            migrationBuilder.UpdateData(
                table: "SaleCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "airbnb");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Properties");

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "Properties",
                type: "decimal(17,15)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "Properties",
                type: "decimal(17,15)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4700a29d-ef7c-4564-a286-643e25d3898f", "AQAAAAEAACcQAAAAEA3Lr7MHTDm1XuUaAUbscflgEKATA/cTcmVN6fsVH29jBo770OkJXGzj86k0FeuxIQ==", "1ed585d5-f72a-4595-bce4-06148d67f0d1" });

            migrationBuilder.UpdateData(
                table: "SaleCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Rbnb");

            migrationBuilder.InsertData(
                table: "SaleCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Rent" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("a3447384-56ea-485d-98d7-0020ad5dc217"),
                columns: new[] { "Latitude", "Longitude", "SaleCategoryId" },
                values: new object[] { 42.64060043988789m, 23.32371168076406m, 2 });
        }
    }
}
