using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace RealEstate.Data.Migrations
{
    public partial class changeLocationValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7863b74c-c19c-497f-a2df-a82e0ef66a42", "AQAAAAEAACcQAAAAEDPbP04C/1LGDER45dHwXETQn7rTcrCtLcU68puvddrqwd+pG5nfGW2RjiYSo5ZnVw==", "65c95722-c9ed-498a-a65a-2806463a9dd1" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("a3447384-56ea-485d-98d7-0020ad5dc217"),
                column: "Location",
                value: (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (23.270974910391605 42.71034632312068)"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
