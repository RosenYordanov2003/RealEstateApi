using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace RealEstate.Data.Migrations
{
    public partial class chnageLocationValueOnSeededProeprty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f2f2abc7-38ab-42f9-88a9-debbc3b717ff", "AQAAAAEAACcQAAAAEFENKwiw/8gdXcpVourKc/2LDhIz1Sg8a/8gDHVjwRPPvcvTsHfLg9SFzyllfDP1Ew==", "2685a5d8-6030-486f-9c5b-e638477e7841" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("a3447384-56ea-485d-98d7-0020ad5dc217"),
                column: "Location",
                value: (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (42.64060043988789 23.323711680764)"));
        }
    }
}
