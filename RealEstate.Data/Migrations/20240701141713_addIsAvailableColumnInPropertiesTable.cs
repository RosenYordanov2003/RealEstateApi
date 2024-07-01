using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstate.Data.Migrations
{
    public partial class addIsAvailableColumnInPropertiesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Properties",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bfb534ff-617d-4806-a644-bc8f85778515", "AQAAAAEAACcQAAAAEF/jTyMEPp9/gkSy4oZU3d+Zi71a/YNowmtL71iBOJSv68tSTo4wmMdymMKvjiRzHg==", "50455ebd-2f22-465f-9453-4c144c4539a7" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Properties");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "36259667-f68f-4475-a7ce-576de48ece18", "AQAAAAEAACcQAAAAEAVwie7hdQlOl3CHN9xivAXbFL5PyKkm92SW/kz0hrrAnhY0OEB82StPWeTnN0jMrw==", "1757346a-5f7b-4466-a319-6f32a119bf65" });
        }
    }
}
