using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace RealEstate.Data.Migrations
{
    public partial class changeValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "644ab4c5-e102-4b44-91ca-f14461c01a16", "AQAAAAEAACcQAAAAEJHzQ1FCJa8pWA0iuxYQzrBn1WbKWPx7AMN40CLOA73vUVkkdZ8EeFY05CHKf+k6hg==", "eb89e8ff-6b63-4765-a11a-c4fe6bd456da" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("a3447384-56ea-485d-98d7-0020ad5dc217"),
                column: "Location",
                value: (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (23.321867 42.697708)"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1df01562-57ab-4374-b412-aad4ad311c9f", "AQAAAAEAACcQAAAAEC0Yd3n7uhj1kj7VQ2l9BjXoAQtFo2umEvqo7mXV5J5DDQqMmjGAQuskmUnz7QgR2A==", "d7eb0044-7fe2-49dd-9699-4e22f2b2fc9c" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("a3447384-56ea-485d-98d7-0020ad5dc217"),
                column: "Location",
                value: (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (23.323711680764 42.64060043988789)"));
        }
    }
}
