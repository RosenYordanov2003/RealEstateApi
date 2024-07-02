using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstate.Data.Migrations
{
    public partial class addTotalPriceColumnInPropertiesRentsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "PropertiesRents",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4700a29d-ef7c-4564-a286-643e25d3898f", "AQAAAAEAACcQAAAAEA3Lr7MHTDm1XuUaAUbscflgEKATA/cTcmVN6fsVH29jBo770OkJXGzj86k0FeuxIQ==", "1ed585d5-f72a-4595-bce4-06148d67f0d1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "PropertiesRents");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9a9a4094-aa73-4e22-a06a-350934f7abfb", "AQAAAAEAACcQAAAAEDyXXSVxlgZO3hhbgYPzZtw+zjNv/XG4NnbMYUxPOU+hgUbOZBugMqJv5JH9fFLkzg==", "065d1212-fc58-43ee-a2fa-5b8a39269a6b" });
        }
    }
}
